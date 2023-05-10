using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Contracts;
using Enemies.Rounds;

namespace GameHandling
{
    public class RoundHandler
    {
        private int currentRound = 0;

        private IList<Round> Rounds = new List<Round>();

        public event Action<Round> RoundStarted;

        public void Initialize(IConfig config)
        {
            currentRound = 0;

            var round = new Round();
            for (var i = 0; i < 10; i++)
            {
                round.Waves.Add(new Wave{Type = EnemyType.SimpleMushroom, Delay = TimeSpan.FromSeconds(2)});
            }
            
            Rounds.Add(round);
        }

        public void StartRound()
        {
            RoundStarted?.Invoke(Rounds[currentRound]);
            currentRound++;
        }
    }
}