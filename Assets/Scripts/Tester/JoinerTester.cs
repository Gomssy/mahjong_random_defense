using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MRD.Test
{
    public class JoinerTester : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            var list = new List<TowerInfo>();

            // 1, 1, 1, 1, 2, 3, 4, 5
            for (int i = 0; i < 2; i++) list.Add(new SingleHaiInfo(new Hai(i, new HaiSpec(HaiType.Sangen, 1))));

            var l = TowerInfoJoiner.Instance.GetAllPossibleSets(list, new List<TowerInfo>());
            var hashset = new HashSet<TowerInfo>();

            foreach (var i in l)
            {
                var s = i.Candidates.ToList();
                var shuntsu = i.Generate();
                hashset.Add(shuntsu);

                Debug.Log($"{shuntsu.GetType().Name} {s[0].Hais[0].Id},{s[1].Hais[0].Id}");
            }

            Debug.Log(hashset.Count);
        }
    }
}
