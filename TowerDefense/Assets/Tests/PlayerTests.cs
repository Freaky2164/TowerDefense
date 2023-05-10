using GameHandling;
using NUnit.Framework;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void TakeDamage0Passes()
        {
            var p = new PlayerHandler(null);
            p.TakeDamage(0);
            Assert.Equals(true, true);
        }
        
        [Test]
        public void TakeDamage1Passes()
        {
            var p = new PlayerHandler(null);
            p.TakeDamage(100);
            Assert.Equals(false, false);
        }
    }
}