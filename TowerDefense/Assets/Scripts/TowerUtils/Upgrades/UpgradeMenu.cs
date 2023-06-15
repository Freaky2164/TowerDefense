using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class UpgradeMenu : MonoBehaviour
    {
        private UpgradeTree _leftTree;
        [CanBeNull] private Upgrade _leftUpgradeScript;
        private UpgradeTree _rightTree;
        [CanBeNull] private Upgrade _rightUpgradeScript;
        [CanBeNull] private BaseTower _tower;

        private void Start()
        {
            _leftUpgradeScript = transform.GetChild(0).gameObject.GetComponent<Upgrade>();
            _rightUpgradeScript = transform.GetChild(1).gameObject.GetComponent<Upgrade>();
            _leftUpgradeScript.enabled = false;
            _rightUpgradeScript.enabled = false;
        }

        public void SetTowerAndProjectile(UpgradeTree upgradeTree, BaseTower tower)
        {
            _tower = tower;
            if (upgradeTree != null)
            {
                _leftTree = upgradeTree.LeftNextUpgrade;
                _rightTree = upgradeTree.RightNextUpgrade;
                SetLeftUpgradeNext();
                SetRightUpgradeNext();
                return;
            }

            if (_leftUpgradeScript != null) _leftUpgradeScript.RemoveUpgrade();
            if (_rightUpgradeScript != null) _rightUpgradeScript.RemoveUpgrade();
        }

        private void SetLeftUpgradeNext()
        {
            if (_leftUpgradeScript != null)
            {
                _leftUpgradeScript.enabled = true;
                _leftUpgradeScript._tower = _tower;
                _leftUpgradeScript.SetUpgrade(_leftTree.Upgrade);
            }
        }

        private void SetRightUpgradeNext()
        {
            if (_rightUpgradeScript != null)
            {
                _rightUpgradeScript.enabled = true;
                _rightUpgradeScript._tower = _tower;
                _rightUpgradeScript.SetUpgrade(_rightTree.Upgrade);
            }
        }

        public void NextUpgrade(GameObject upgrade)
        {
            if (upgrade.CompareTag("LeftUpgrade"))
            {
                _leftTree = _leftTree.LeftNextUpgrade;
                SetLeftUpgradeNext();
                _tower.SetNewLeftUpgrade(_leftTree);
            }

            if (upgrade.CompareTag("RightUpgrade"))
            {
                _rightTree = _rightTree.RightNextUpgrade;
                SetRightUpgradeNext();
                _tower.SetNewRightUpgrade(_rightTree);
            }
        }
    }
}