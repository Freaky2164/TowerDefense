namespace TowerDefense.Plugins.Money.Tests;

public class MoneyHandler_GainMoneyShould
{
    [Theory]
    [InlineData(100)]
    [InlineData(200)]
    [InlineData(300)]
    public void GainMoney(int value)
    {
        var money = new MoneyHandler();
        
        money.GainMoney(value);
        
        Assert.Equal(value, money.Money);
    }
}