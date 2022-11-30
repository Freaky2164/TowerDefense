using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public EnemyHandler enemyHandler;
    private EnemySpawner enemySpawner;
    private FinancialSystem financialSystem;
    private int round = 1;

    void Start()
    {
        financialSystem = new FinancialSystem(1000);
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    public void enemyDestroyed(int id, int value)
    {
        financialSystem.gainMoney(value);
        if (id == 0)
        {
            round++;
            enemySpawner.setEnemies(enemyHandler.getEnemies(round));
            Debug.Log("End round");
        }
    }


    public void startRound()
    {
        enemySpawner.setEnemies(enemyHandler.getEnemies(round));
        enemySpawner.activate();
    }
}
