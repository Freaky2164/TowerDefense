using System;
using System.Collections.Generic;
using System.Linq;
using Enemies.Rounds;
using GameHandling;
using UnityEngine;
using UnityEngine.Splines;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _spawnTimer = 0;

        [SerializeField]
        private SplineContainer path;
        
        private Enemies _enemies;

        private void Start()
        {
            _enemies = GetComponent<Enemies>();
            
            GameHandler.I.Rounds.RoundStarted += OnRoundStarted;
            GameHandler.I.Rounds.RoundEnded += OnRoundEnded;

            enabled = false;
        }

        private void Update()
        {
            if (!enabled) return;
            if (!TimerFinished()) return;
            
            SpawnWave();
        }

        private void SpawnWave()
        {
            if (!GameHandler.I.Rounds.TryGetNextEnemy(out var enemy)) return;
            switch (enemy.Type)
            {
                case EnemyType.SimpleMushroom:
                    CreateEnemy(_enemies.Enemy1Prf);
                    break;
            }

            _spawnTimer = (float) enemy.Delay.TotalSeconds;
        }
        
        private void CreateEnemy(GameObject enemy)
        {
            var enemyGameObject = Instantiate(enemy, transform.position, enemy.transform.rotation);
        
            var enemyComponent = enemyGameObject.GetComponent<Enemy>();
            enemyComponent.Path = path;
        }

        private bool TimerFinished()
        {
            _spawnTimer -= Time.deltaTime;
            if (!(_spawnTimer <= 0)) return false;
            _spawnTimer = 0.1F;
            return true;
        }
    
        private void OnRoundStarted(Round round)
        {
            enabled = true;
        }

        private void OnRoundEnded()
        {
            enabled = false;
        }
    }
}