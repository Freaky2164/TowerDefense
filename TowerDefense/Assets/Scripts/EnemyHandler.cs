using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHandler : MonoBehaviour
{
    public GameObject enemy1Prf;
    public static int enemyAmount = 20;

    public Stack<GameObject> getEnemies(int wave)
    {
        Stack<GameObject> enemies = new Stack<GameObject>();
        switch (wave)
        {
            case 1: enemies = getEnemiesWave1();
                    break;
        }
        return enemies;
    }

    public Stack<GameObject> getEnemiesWave1()
    {
        Stack<GameObject> enemies = new Stack<GameObject>();
        for (int i = 0; i < enemyAmount; i++)
        {
            enemies.Push(enemy1Prf);
        }
        return enemies;
    }
}
