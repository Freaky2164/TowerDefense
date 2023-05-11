using System;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class CanonTowerUpgrades
    {
        private UpgradeTree _upgradeTree;
        
        public UpgradeTree GetUpgradeTree()
        {
            _upgradeTree = new UpgradeTree
            {
                Upgrade = null,
                LeftNextUpgrade = GetLeftUpgrades(),
                RightNextUpgrade = GetRightUpgrades()
            };
            return _upgradeTree;
        }

        private UpgradeTree GetLeftUpgrades()
        {
            Action<BaseTower> addAoEAction = AddAoE;
            Action<BaseTower> bla = Bla;
            UpgradeTree left = new UpgradeTree
            {
                Upgrade = new Upgrade(addAoEAction, 100),
                LeftNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(bla, 100),
                }
            };
            return left;
            
            void Bla(BaseTower arg1)
            {
                var attackRangeRenderer = arg1.transform.GetChild(0).gameObject.transform;
                attackRangeRenderer.localScale += new Vector3(10F, 10F);
            }
            
            void AddAoE(BaseTower arg1)
            {
                var test = (Projectile)Resources.Load("Prefabs/Pigs/Projectiles/LaserWithAoE", typeof(Projectile));
                arg1.projectile = test;
            }
        }
        
        private UpgradeTree GetRightUpgrades()
        {
            Action<BaseTower> asBuff = AsBuff;
            Action<BaseTower> moreMoney = MoreMoney;
            UpgradeTree tree = new UpgradeTree
            {
                Upgrade = new Upgrade(asBuff, 100),
                RightNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(moreMoney, 100),
                }
            };
            return tree;
            
            
            void MoreMoney(BaseTower arg1)
            { 
                arg1.AdditionalMoneyPerHit += 5;
            }
            
            void AsBuff(BaseTower arg1)
            {
                arg1.attackSpeed += 2;
            }
        }
    }
}