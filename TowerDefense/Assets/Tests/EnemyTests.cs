using Enemies;
using NUnit.Framework;

namespace Tests
{
    public class EnemyTests
    {
        [Test]
        public void DamageEnemyPasses()
        {
            var e = new Enemy();
            e.Damage(100);
            Assert.Equals(false, e.HasHealthLeft());
        }
    }
}
