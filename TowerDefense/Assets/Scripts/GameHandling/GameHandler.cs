using Contracts;
using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameHandling
{
    public class GameHandler : MonoBehaviour
    {
        private IConfig _config;
        private static GameHandler _i;
        public static GameHandler I => _i ??= Instantiate(Resources.Load(nameof(GameHandler)) as GameObject).GetComponent<GameHandler>();

        [SerializeField]
        private EnemyHandler enemyHandler;

        [SerializeField] 
        private Config config;
        
        public IConfig Config
        {
            get => _config ??= config ?? gameObject.AddComponent<Config>();
            set => _config = value;
        }

        private EnemySpawner enemySpawner;
        private int round = 1;

        public PlayerHandler Player { get; private set; }
        public MoneyHandler Finances { get; private set; }

        private void Start()
        {
            _i = this;

            Player = new PlayerHandler(Config);
            Player.Died += OnDied;
        
            Finances = new MoneyHandler(Config);
            enemySpawner = GameObject.Find(nameof(EnemySpawner)).GetComponent<EnemySpawner>();
        }

        public void StartRound()
        {
            enemySpawner.Enemies = enemyHandler.GetEnemiesOfWave(round);
            enemySpawner.Activate();
            AudioManager.instance.Play("ButtonClick");
        }

        public void EnemyDestroyed(int id, int value)
        {
            AudioManager.instance.Play("EnemyDestroyed");
            if (id != 0) return;
            round++;
            enemySpawner.Enemies = enemyHandler.GetEnemiesOfWave(round);
            Debug.Log("End round");
        }

        private void OnDied()
        {
            Debug.Log("Game OVER!");
            SceneManager.LoadScene(0);
        }
    }
}