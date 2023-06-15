using System;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TowerUtils.Upgrades
{
    public class BombTowerUpgrades
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
            Action<BaseTower> increaseAoE = IncreaseAoE;
            Action<BaseTower> range = Range;
            Action<BaseTower> mimimi = DoesNothing;
            UpgradeTree left = new UpgradeTree
            {
                Upgrade = new Upgrade(increaseAoE, 100, "MEHR AOE"),
                LeftNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(range, 300, "Mehr Reichweite"),
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
            
            void IncreaseAoE(BaseTower arg1)
            {
                arg1.AdditionalAoERange += new Vector3(2F, 2F);
            }
        }
        
        private UpgradeTree GetRightUpgrades()
        {
            Action<BaseTower> asBuff = AsBuff;
            Action<BaseTower> moreMoney = MoreMoney;
            Action<BaseTower> mimimi = DoesNothing;
            UpgradeTree tree = new UpgradeTree
            {
                Upgrade = new Upgrade(asBuff, 200, "Sprengt alles in die Luft"),
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