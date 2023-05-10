namespace Contracts
{
    public interface IConfig
    {
        public static IConfig Default => new DefaultConfig();
        
        int MaxPlayerHealth { get; }
        int StartMoney { get; }
        
        public class DefaultConfig : IConfig
        {
            public int MaxPlayerHealth => 1000;
            public int StartMoney => 100;
        }
        
    }
}