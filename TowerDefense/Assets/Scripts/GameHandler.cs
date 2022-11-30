using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    private static GameHandler _i;
    public static GameHandler i {
        get
        {
            _i ??= Instantiate(Resources.Load("GameHandler") as GameObject).GetComponent<GameHandler>();
            return _i;
        }
    }

    public Player Player { get; private set; }
    
    public EnemyHandler enemyHandler;
    private EnemySpawner _enemySpawner;
    private int _round = 1;

    public FinancialSystem FinancialSystem { get; set; }

    private void Start()
    {
        _i = this;
        
        Player = GetComponent<Player>();
        Player.PlayerDied += OnPlayerDied;
        
        FinancialSystem = new FinancialSystem(1000);
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    public void StartRound()
    {
        _enemySpawner.Enemies = enemyHandler.GetEnemiesOfWave(_round);
        _enemySpawner.Activate();
    }

    public void EnemyDestroyed(int id, int value)
    {
        FinancialSystem.GainMoney(value);
        if (id != 0) return;
        _round++;
        _enemySpawner.Enemies = enemyHandler.GetEnemiesOfWave(_round);
        Debug.Log("End round");
    }

    private void OnPlayerDied()
    {
        Debug.Log("Game OVER!");
    }
}