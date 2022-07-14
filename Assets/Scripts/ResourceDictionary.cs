using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MRD
{
    public static class ResourceDictionary
    {
        private static readonly Dictionary<string, object> Dict = new();

        public static object Get(string path)
        {
            if (Dict.TryGetValue(path, out object obj))
            {
                return obj;
            }
            else
            {
                object temp = Resources.Load(path);
                Dict.Add(path, temp);
                return temp;
            }
        }
        public static T Get<T>(string path) where T : class => Get(path) as T;

        public static object[] GetAll(string path)
        {
            if (Dict.TryGetValue(path, out object obj))
            {
                return obj as object[];
            }
            else
            {
                object[] temp = Resources.LoadAll(path);
                Dict.Add(path, temp);
                return temp;
            }
        }

        public static T[] GetAll<T>(string path) => GetAll(path) as T[];
    }
}
