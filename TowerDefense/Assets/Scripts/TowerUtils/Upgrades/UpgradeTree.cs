using JetBrains.Annotations;

namespace TowerUtils.Upgrades
{
    public class UpgradeTree
    {
        [CanBeNull] public Upgrade Upgrade;
        [CanBeNull] public UpgradeTree LeftNextUpgrade;
        [CanBeNull] public UpgradeTree RightNextUpgrade;
    }
}