using System;
using Contracts;

namespace GameHandling
{
    public class MoneyHandler
    {
        private int _money;

        public int Money
        {
            get => _money;
            private set
            {
                _money = value;
                MoneyChanged?.Invoke(value);
            }
        }

        public event Action<int> MoneyChanged;

        public MoneyHandler(IConfig config)
        {
            Money = config.StartMoney;
        }
        
        public void GainMoney(int amount)
        {
            Money += amount;
        }

        public bool TryBuy(int amount)
        {
            if (Money < amount) return false;

            Money -= amount;
            return true;
        }
    }
}