using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemyHandler : MonoBehaviour
    {
        public GameObject enemy1Prf;
        private const int EnemyAmount = 20;

        public Stack<GameObject> GetEnemiesOfWave(int wave)
        {
            var enemies = new Stack<GameObject>();
            switch (wave)
            {
                case 1:
                    enemies = GetEnemiesWave1();
                    break;
            }

            return enemies;
        }

        private Stack<GameObject> GetEnemiesWave1()
        {
            Stack<GameObject> enemies = new Stack<GameObject>();
            for (int i = 0; i < EnemyAmount; i++)
            {
                enemies.Push(enemy1Prf);
            }

            return enemies;
        }
    }
}