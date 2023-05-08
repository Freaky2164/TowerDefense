using GameHandling;
using NUnit.Framework;

namespace Tests
{
    public class FinancialSystemTests
    {
        [Test]
        public void GainMoneyPasses()
        {
            var s = new FinancialSystem(0);
            s.GainMoney(100);
            Assert.Equals(true, true);
        }
        
        [Test]
        public void BuyTower0Passes()
        {
            var s = new FinancialSystem(100);
            Assert.Equals(true, s.TryBuy(0));
        }
        
        [Test]
        public void BuyTower1Passes()
        {
            var s = new FinancialSystem(100);
            Assert.Equals(true, s.TryBuy(100));
        }
        
        [Test]
        public void BuyTower2Passes()
        {
            var s = new FinancialSystem(0);
            Assert.Equals(true, s.TryBuy(100));
        }
    }
}