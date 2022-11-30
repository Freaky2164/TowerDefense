using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public EnemyHandler enemyHandler;
    private EnemySpawner _enemySpawner;
    private int _round = 1;

    public FinancialSystem FinancialSystem { get; set; }

    private void Start()
    {
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
}