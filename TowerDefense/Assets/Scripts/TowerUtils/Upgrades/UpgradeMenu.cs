using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class UpgradeMenu: MonoBehaviour
    {
        private UpgradeTree _upgradeTree;
        private GameObject _leftUpgrade;
        private GameObject _rightUpgrade;
        [CanBeNull] public BaseTower tower;
        [CanBeNull] public Projectile projectile;
        private bool _isIn = false;

        public void SetTowerAndProjectile(BaseTower tower,Projectile projectile)
        {
            this.tower = tower;
            this.projectile = projectile;
        }

        private void Start()
        {
            _upgradeTree = new CanonTowerUpgrades().GetUpgradeTree();
            _leftUpgrade = transform.GetChild(0).gameObject;
            _rightUpgrade = transform.GetChild(1).gameObject;
            
        }

        private void Update()
        {
            if (!_isIn && _leftUpgrade.GetComponent<Upgrade>().IsInitialized && _rightUpgrade.GetComponent<Upgrade>().IsInitialized)
            {
                SetLeftUpgrade(_upgradeTree.LeftNextUpgrade.Upgrade);
                SetRightUpgrade(_upgradeTree.RightNextUpgrade.Upgrade);
                _isIn = true;
            }
        }

        private void SetLeftUpgrade(Upgrade upgrade)
        {
            var upgradeScript = _leftUpgrade.GetComponent<Upgrade>();
            upgradeScript.UpgradeAction = upgrade.UpgradeAction;
            upgradeScript._tower = tower;
            upgradeScript._projectile = projectile;
        }
        private void SetRightUpgrade(Upgrade upgrade)
        {
            var upgradeScript = _rightUpgrade.GetComponent<Upgrade>();
            upgradeScript.UpgradeAction = upgrade.UpgradeAction;
            upgradeScript._tower = tower;
            upgradeScript._projectile = projectile;        }
    }
}