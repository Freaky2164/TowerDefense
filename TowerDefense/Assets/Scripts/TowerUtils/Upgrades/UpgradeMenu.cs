using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class UpgradeMenu: MonoBehaviour
    {
        private GameObject _leftUpgrade;
        private Upgrade _leftUpgradeScript;
        private GameObject _rightUpgrade;
        [CanBeNull] public BaseTower tower;
        [CanBeNull] public Projectile projectile;

        public void SetTowerAndProjectile(BaseTower tower,Projectile projectile)
        {
            _leftUpgradeScript._tower = tower;
            _leftUpgradeScript._projectile = projectile;
        }

        private void Update()
        {
            _leftUpgrade = transform.GetChild(0).gameObject;
            _leftUpgradeScript = GetComponentInChildren<Upgrade>();
            _rightUpgrade = transform.GetChild(1).gameObject;
        }

        public void test()
        {
            _leftUpgradeScript.PerformAction();
        }
    }
}