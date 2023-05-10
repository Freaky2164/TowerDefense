using System.Collections.Generic;

namespace Enemies.Rounds
{
    public class Round
    {
        public IList<Wave> Waves { get; set; } = new List<Wave>();
    }
}