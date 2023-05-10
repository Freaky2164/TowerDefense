using Contracts;
using Enemies;

namespace GameHandling
{
    public class EnemyHandler
    {
        public void Initialize(IConfig config)
        {
            
        }

        public void RaiseEnemyDestroyed(Enemy enemy)
        {
            AudioHandler.I.Play(enemy.DieSound);
        }
    }
}