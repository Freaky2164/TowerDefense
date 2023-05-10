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
            Action<BaseTower, Projectile> addAoEAction = AddAoE;
            Action<BaseTower, Projectile> bla = Bla;
            UpgradeTree left = new UpgradeTree
            {
                Upgrade = new Upgrade(addAoEAction, 100),
                LeftNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(bla, 100),
                }
            };
            return left;
            
            void Bla(BaseTower arg1, Projectile arg2)
            {
                var attackRangeRenderer = arg1.transform.GetChild(0).gameObject.transform;
                attackRangeRenderer.localScale += new Vector3(10F, 10F);

                arg2.damage += 1;
            }
            
            void AddAoE(BaseTower arg1, Projectile arg2)
            {
                arg2.AddComponent<CircleCollider2D>();
                var collider = arg2.GetComponent<CircleCollider2D>();
                collider.radius = 4F;
            }
        }
        
        private UpgradeTree GetRightUpgrades()
        {
            Action<BaseTower, Projectile> asBuff = AsBuff;
            Action<BaseTower, Projectile> moreMoney = MoreMoney;
            UpgradeTree tree = new UpgradeTree
            {
                Upgrade = new Upgrade(asBuff, 100),
                RightNextUpgrade = new UpgradeTree
                {
                    Upgrade = new Upgrade(moreMoney, 100),
                }
            };
            return tree;
            
            
            void MoreMoney(BaseTower arg1, Projectile arg2)
            {
                arg2.moneyPerHit += 5;
            }
            
            void AsBuff(BaseTower arg1, Projectile arg2)
            {
                arg1.attackSpeed += 2;
            }
        }
    }
}