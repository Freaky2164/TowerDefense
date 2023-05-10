using Audio;
using Contracts;
using Enemies;
using TowerUtils.Upgrades;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameHandling
{
    public class GameHandler : MonoBehaviour
    {
        private IConfig _config;
        public static GameHandler I { get; private set; }

        public UpgradeMenu upgradeMenu;

        [SerializeField] 
        private Configuration config;
        
        public IConfig Config
        {
            get => _config ??= config as IConfig ?? IConfig.Default;
            set => _config = value;
        }

        public PlayerHandler Player { get; } = new();
        public MoneyHandler Finances { get; } = new();
        public EnemyHandler Enemies { get; } = new();
        public RoundHandler Rounds { get; } = new();

        public GameHandler()
        {
            I = this;
            Player.Died += OnDied;
        }
        
        private void Start()
        {
            Player.Initialize(Config);
            Finances.Initialize(Config);
            Enemies.Initialize(Config);
            Rounds.Initialize(Config);
        }

        private void OnDied()
        {
            Debug.Log("Game OVER!");
            SceneManager.LoadScene(0);
        }
    }
}