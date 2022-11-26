using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public EnemyHandler enemyHandler;
    private FinancialSystem financialSystem;
    private int round = 1;

    void Start()
    {
        financialSystem = new FinancialSystem(1000);
        EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        enemySpawner.setEnemies(enemyHandler.getEnemies(round));
        enemySpawner.activate();
    }

    public void enemyDestroyed(int value)
    {
        financialSystem.gainMoney(value);
    }
}
