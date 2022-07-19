using System.Collections.Generic;
using UnityEngine;

namespace MRD
{
    [RequireComponent(typeof(Grid))]
    public class RoundManager : Singleton<RoundManager>
    {
        public bool DEBUG_MODE;
        public RoundNum round { get; private set; }
        public EnemySpawner Spawner => GetComponent<EnemySpawner>();
        public Grid Grid => GetComponent<Grid>();
        public float playSpeed { get; private set; }
        public int TsumoToken { get; private set; } = 0;

        public List<EnemyController> EnemyList = new(); // 현재 필드 위에 있는 적 리스트

        private void ResetGame()
        {
            Grid.ResetGame();
        }

        private void InitGame()
        {
            playSpeed = 1f;
            Grid.InitGame();
            ResetGame();
        }

        private void Start()
        {
            if(!DEBUG_MODE)
                InitGame();
        }

        public void PlusTsumoToken(int GetToken)
        {
            TsumoToken += GetToken;
            return;
        }

        public bool MinusTsumoToken(int UseToken)
        {
            if (TsumoToken < UseToken)
            {
                return false;
            }
            else
            {
                TsumoToken -= UseToken;
                return true;
            }
        }

        public void OnEnemyCreate(EnemyController enemy)
        {
            EnemyList.Add(enemy);
        }

        public void OnEnemyDestroy(EnemyController enemy)
        {
            for (int i = EnemyList.Count - 1; i > 0; i--)
            {
                if (EnemyList[i] != enemy) continue;

                EnemyList.RemoveAt(i);
                return;
            }
        }
    }

    public struct RoundNum
    {
        public int season { get; private set; }
        public int wind { get; private set; }
        public int number { get; private set; }

        // ���� ���� �� true
        public bool NextRound()
        {
            number++;
            if (number > 3)
            {
                number = 0;
                wind++;
            }
            if (wind > 3)
            {
                wind = 0;
                season++;
            }
            if (season > 3)
            {
                return true;
            }
            return false;
        }
    }
}