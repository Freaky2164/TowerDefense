using System;
using System.Collections.Generic;
using Enemies.Rounds;
using TowerDefense.Plugins.Base.Contracts;

namespace GameHandling
{
    public class RoundHandler
    {
        private int _roundCount = 0;
        private int _enemyCount = 0;
        private Round _activeRound;
        
        private IList<Round> Rounds = new List<Round>();

        public event Action<Round> RoundStarted;
        public event Action RoundEnded;
        public event Action GameFinished; 

        public void Initialize(IConfig config)
        {
            _roundCount = 0;

            var round = new Round();
            for (var i = 0; i < 20; i++)
            {
                round.Waves.Add(new Wave{Type = EnemyType.SimpleMushroom, Delay = TimeSpan.FromSeconds(1)});
            }
            
            Rounds.Add(round);

            round = new Round();
            for (var i = 0; i < 30; i++)
            {
                round.Waves.Add(new Wave{Type = EnemyType.SimpleMushroom, Delay = TimeSpan.FromSeconds(0.5)});
            }
            
            Rounds.Add(round);

            round = new Round();
            for (var i = 0; i < 50; i++)
            {
                round.Waves.Add(new Wave{Type = EnemyType.SimpleMushroom, Delay = TimeSpan.FromSeconds(0.5)});
            }
            
            Rounds.Add(round);
        }

        public void StartRound()
        {
            if (_roundCount >= Rounds.Count)
            {
                RaiseGameFinished();
                return;
            }
            
            _activeRound = Rounds[_roundCount];

            _enemyCount = 0;
            RaiseRoundStarted(_activeRound);
            
            _roundCount++;
        }

        public bool TryGetNextEnemy(out Wave enemy)
        {
            enemy = null;
            
            if (_enemyCount >= _activeRound.Waves.Count)
            {
                RaiseRoundEnded();
                return false;
            }

            enemy = _activeRound.Waves[_enemyCount];
            return true;
        }

        private void RaiseRoundStarted(Round round)
        {
            RoundStarted?.Invoke(round);
        }

        private void RaiseRoundEnded()
        {
            RoundEnded?.Invoke();
        }

        private void RaiseGameFinished()
        {
            GameFinished?.Invoke();
        }
    }
}