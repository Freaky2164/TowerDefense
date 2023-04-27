using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerUtils.Upgrades
{
    public class Upgrade: MonoBehaviour
    { 
        public Action<BaseTower, Projectile> UpgradeAction { get; set; } 
        public int Cost;
        [CanBeNull] public BaseTower _tower;
        [CanBeNull] public Projectile _projectile;

        public bool IsInitialized { get; private set;}

        public Upgrade(Action<BaseTower, Projectile> action, int cost)
        {
            UpgradeAction = action;
            Cost = cost;
        }

        private void Start()
        {
            IsInitialized = true;
        }

        public void PerformAction()
        {
            Debug.Log("Clicked");
            UpgradeAction.Invoke(_tower, _projectile);
        }
    }
}