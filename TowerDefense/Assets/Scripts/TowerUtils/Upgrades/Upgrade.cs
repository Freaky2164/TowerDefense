using System;
using GameHandling;
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
        public GameObject menu;
        private UpgradeMenu _parentScript;

        public bool IsInitialized { get; private set;}

        public Upgrade(Action<BaseTower, Projectile> action, int cost)
        {
            UpgradeAction = action;
            Cost = cost;
        }

        private void Start()
        {
            _parentScript = menu.GetComponent<UpgradeMenu>();
            IsInitialized = true;
        }

        public void SetUpgrade(Upgrade upgrade)
        {
            UpgradeAction = upgrade.UpgradeAction;
            Cost = upgrade.Cost;
        }

        public void PerformAction()
        {
            if (!GameHandler.I.Finances.TryBuy(Cost)) return;
            UpgradeAction.Invoke(_tower, _projectile); 
            _parentScript.NextUpgrade(gameObject);
        }
    }
}