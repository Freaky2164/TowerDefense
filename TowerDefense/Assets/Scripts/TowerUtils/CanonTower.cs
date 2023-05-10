using Audio;
using TowerUtils.Upgrades;

namespace TowerUtils
{
    public class CanonTower: BaseTower
    {
        protected override void Initialize()
        {
            ShotSound = Sound.CanonTowerShot;
            upgradeTree = new CanonTowerUpgrades().GetUpgradeTree();
        }
    }
}