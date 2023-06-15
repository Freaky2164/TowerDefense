using Audio;
using TowerUtils.Upgrades;

namespace TowerUtils
{
    public class BombTower: BaseTower
    {
        protected override void Initialize()
        {
            ShotSound = Sound.BombTowerShot;
            upgradeTree = new BombTowerUpgrades().GetUpgradeTree();
        }
    }
}