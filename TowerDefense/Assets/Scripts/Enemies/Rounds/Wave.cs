using System;

namespace Enemies.Rounds
{
    public interface IWave
    {
        public EnemyType Type { get; }
        public TimeSpan Delay { get; }
    }
    
    public class Wave : IWave
    {
        public EnemyType Type { get; set; }
        public TimeSpan Delay { get; set; }
    }

    public class WaveDelay : IWave
    {
        public EnemyType Type => EnemyType.Delay;
        public TimeSpan Delay { get; set; }
    }
}