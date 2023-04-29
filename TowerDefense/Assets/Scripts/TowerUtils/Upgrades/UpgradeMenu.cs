using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class UpgradeMenu: MonoBehaviour
    {
        private UpgradeTree _upgradeTree;
        private GameObject _leftUpgradeScript;
        private GameObject _rightUpgradeScript;
        private UpgradeTree _leftTree;
        private UpgradeTree _rightTree;
        [CanBeNull] public BaseTower tower;
        [CanBeNull] public Projectile projectile;
        private bool _isIn;

        public void SetTowerAndProjectile(BaseTower tower,Projectile projectile)
        {
            this.tower = tower;
            this.projectile = projectile;
        }

        private void Start()
        {
            _upgradeTree = new CanonTowerUpgrades().GetUpgradeTree();
            _leftUpgradeScript = transform.GetChild(0).gameObject;
            _rightUpgradeScript = transform.GetChild(1).gameObject;
            _leftTree = _upgradeTree.LeftNextUpgrade;
            _rightTree = _upgradeTree.RightNextUpgrade;
        }

        private void Update()
        {
            if (tower && !_isIn && _leftUpgradeScript.GetComponent<Upgrade>().IsInitialized && _rightUpgradeScript.GetComponent<Upgrade>().IsInitialized)
            {
                SetLeftUpgradeNext();
                SetRightUpgradeNext();
                _isIn = true;
            }
        }

        private void SetLeftUpgradeNext()
        {
            var upgradeScript = _leftUpgradeScript.GetComponent<Upgrade>();
            if (!_isIn)
            { 
                upgradeScript._tower = tower; 
                upgradeScript._projectile = projectile;
            }

            if (_leftTree.IsUnityNull())
            {
                //ToDo add no more upgrades available
                return;
            }
            upgradeScript.SetUpgrade(_leftTree.Upgrade);
            _leftTree = _leftTree.LeftNextUpgrade;
        }
        private void SetRightUpgradeNext()
        {
            var upgradeScript = _rightUpgradeScript.GetComponent<Upgrade>();
            if (!_isIn)
            { 
                upgradeScript._tower = tower; 
                upgradeScript._projectile = projectile;
            }
            if (_rightTree.IsUnityNull())
            {
                //ToDo add no more upgrades available
                return;
            }
            upgradeScript.SetUpgrade(_rightTree.Upgrade);
            _rightTree = _rightTree.LeftNextUpgrade;        }

        public void NextUpgrade(GameObject upgrade)
        {
            if (upgrade.CompareTag("LeftUpgrade"))
            {
                SetLeftUpgradeNext();
            }
            if (upgrade.CompareTag("RightUpgrade"))
            {
                SetRightUpgradeNext();
            }
        }
    }
}