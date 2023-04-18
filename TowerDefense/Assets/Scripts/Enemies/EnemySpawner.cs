using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _spawnTimer = 1;
        public Stack<GameObject> Enemies { get; set; }

        [SerializeField]
        private SplineContainer path;
    
        private void Update()
        {
            if (!TimerFinished()) return;
            if (!Enemies.Any())
            {
                Deactivate();
                return;
            }
        
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            var enemy = Enemies.Pop();
            var enemyGameObject = Instantiate(enemy, transform.position, enemy.transform.rotation);
        
            var enemyComponent = enemyGameObject.GetComponent<Enemy>();
            enemyComponent.ID = Enemies.Count;
            enemyComponent.Path = path;
        }

        private bool TimerFinished()
        {
            _spawnTimer -= Time.deltaTime;
            if (!(_spawnTimer <= 0)) return false;
            _spawnTimer = 0.1F;
            return true;
        }
    
        public void Activate()
        {
            enabled = true;
        }

        public void Deactivate()
        {
            enabled = false;
        }
    }
}