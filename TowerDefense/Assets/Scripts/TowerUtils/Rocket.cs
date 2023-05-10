using System.Collections.Generic;
using Enemies;
using GameHandling;
using UnityEngine;

namespace TowerUtils
{
    public class Rocket : Projectile
    {
        private Collider2D _explosionRangeCollider;
        
        protected override void Initialize()
        {
            _explosionRangeCollider = transform.GetChild(0).GetComponent<Collider2D>();
        }
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            var enemiesInRange = GetOverlappingCollider();
            foreach (var enemyCollider in enemiesInRange)
            {
                var enemy = enemyCollider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Damage(damage); 
                    GameHandler.I.Finances.GainMoney(moneyPerHit);
                    if (!enemy.HasHealthLeft())
                    {
                        Destroy(enemyCollider.gameObject);
                    }
                }
            }
            Destroy(gameObject);
        }
        
        private List<Collider2D> GetOverlappingCollider()
        {
            var filter = new ContactFilter2D().NoFilter();
            var results = new List<Collider2D>();
            Physics2D.OverlapCollider(_explosionRangeCollider, filter, results);
            return results.FindAll(collider1 => collider1.gameObject.CompareTag("Enemy"));
        }
    }
}
