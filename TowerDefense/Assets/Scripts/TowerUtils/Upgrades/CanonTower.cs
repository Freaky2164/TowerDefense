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
            Action<BaseTower> range = Range;
            Action<BaseTower> mimimi = DoesNothing;
            UpgradeTree left = new UpgradeTree
            {
                Upgrade = new Upgrade(addAoEAction, 240, "!Canon Tower anymore"),
                LeftNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(range, 400, "Es kommt auf die Reichweite an"),
                    LeftNextUpgrade = new UpgradeTree
                    {
                        Upgrade = new Upgrade(mimimi, 00000000, "Mehr Upgrades..."),
                    }
                }
            };
            return left;
            
            void Range(BaseTower arg1)
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
            Action<BaseTower> mimimi = DoesNothing;
            UpgradeTree tree = new UpgradeTree
            {
                Upgrade = new Upgrade(asBuff, 300, "It goes Ratatatatatatatata"),
                RightNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(moreMoney, 69420, "Mehr Geld"),
                    RightNextUpgrade = new UpgradeTree
                    {
                        Upgrade = new Upgrade(mimimi, 00000000, "Mehr Upgrades..."),
                    }
                }
            };
            return tree;
            
            
            void MoreMoney(BaseTower arg1)
            { 
                arg1.AdditionalMoneyPerHit += 100;
            }
            
            void AsBuff(BaseTower arg1)
            {
                arg1.attackSpeed += 5;
            }
        }

        void DoesNothing(BaseTower arg1)
        {
        }
    }
}