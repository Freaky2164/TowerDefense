using JetBrains.Annotations;

namespace TowerUtils.Upgrades
{
    public class UpgradeTree
    {
        public Upgrade Upgrade;
        [CanBeNull] public UpgradeTree LeftNextUpgrade;
        [CanBeNull] public UpgradeTree RightNextUpgrade;
    }
}