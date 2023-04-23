using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameHandling
{
    public class GameHandler : MonoBehaviour
    {
        private static GameHandler _i;
        public static GameHandler I {
            get
            {
                _i ??= Instantiate(Resources.Load("GameHandler") as GameObject).GetComponent<GameHandler>();
                return _i;
            }
        }

        public Player Player { get; private set; }

        [SerializeField]
        private EnemyHandler enemyHandler;
    
        private EnemySpawner enemySpawner;
        private int round = 1;

        public FinancialSystem FinancialSystem { get; set; }

        private void Start()
        {
            _i = this;
        
            Player = GetComponent<Player>();
            Player.PlayerDied += OnPlayerDied;
        
            FinancialSystem = new FinancialSystem(1000);
            enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        }

        public void StartRound()
        {
            enemySpawner.Enemies = enemyHandler.GetEnemiesOfWave(round);
            enemySpawner.Activate();
            AudioManager.instance.Play("ButtonClick");
        }

        public void EnemyDestroyed(int id, int value)
        {
            if (id != 0) return;
            round++;
            enemySpawner.Enemies = enemyHandler.GetEnemiesOfWave(round);
            Debug.Log("End round");
        }

        private void OnPlayerDied()
        {
            Debug.Log("Game OVER!");
            SceneManager.LoadScene(0);
        }
    }
}