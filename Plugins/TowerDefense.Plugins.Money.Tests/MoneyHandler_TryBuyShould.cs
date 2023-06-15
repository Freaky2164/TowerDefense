namespace TowerDefense.Plugins.Money.Tests;

public class MoneyHandler_TryBuyShould
{
    [Theory]
    [InlineData(0, 100)]
    [InlineData(100, 200)]
    [InlineData(100, 300)]
    public void TryBuy_ValueMoreThenMoney_ReturnFalse(int money, int value)
    {
        var handler = new MoneyHandler{Money = money};

        var result = handler.TryBuy(value);
        
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(100, 0)]
    [InlineData(100, 50)]
    [InlineData(100, 100)]
    public void TryBuy_ValueLessEqualsThenMoney_ReturnTrue(int money, int value)
    {
        var handler = new MoneyHandler{Money = money};

        var result = handler.TryBuy(value);
        
        Assert.True(result);
    }
}