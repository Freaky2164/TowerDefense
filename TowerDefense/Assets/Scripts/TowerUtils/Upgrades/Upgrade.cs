using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class Upgrade: MonoBehaviour
    { 
        private Action<BaseTower, Projectile> UpgradeAction { get; set; } 
        private int Cost;
        [CanBeNull] public BaseTower _tower;
        [CanBeNull] public Projectile _projectile;
        private UpgradeMenu _menu;
        private Camera _camera;
        
        public bool IsInitialized { get; private set;}

        public Upgrade(Action<BaseTower, Projectile> action, int cost)
        {
            UpgradeAction = action;
            Cost = cost;
        }

        private void Start()
        {
            _camera = Camera.main;
            _menu = GetComponentInParent<UpgradeMenu>();
            IsInitialized = true;
        }

        public void PerformAction()
        {
            UpgradeAction.Invoke(_tower, _projectile);
        }
    }
}