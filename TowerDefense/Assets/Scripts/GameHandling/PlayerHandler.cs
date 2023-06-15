using System;
using TowerDefense.Plugins.Base.Contracts;

namespace GameHandling
{
    public class PlayerHandler
    {
        private int _health;

        public event Action Died;
        public event Action<int> DamageTaken;
        public event Action<int> HealthChanged;

        public int Health
        {
            get => _health;
            private set
            {
                _health = value;
                HealthChanged?.Invoke(value);
            }
        }

        public void Initialize(IConfig config)
        {
            Health = config.MaxPlayerHealth;
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            DamageTaken?.Invoke(damage);
            if (_health <= 0) Died?.Invoke();
        }
    }
}