using Contracts;
using UnityEngine;

namespace GameHandling
{
    public class Configuration : MonoBehaviour, IConfig
    {
        [SerializeField]
        private int maxPlayerHealth = 100;

        [SerializeField] 
        private int startMoney = 1000;
        
        public int MaxPlayerHealth => maxPlayerHealth;
        public int StartMoney => startMoney;
    }
}