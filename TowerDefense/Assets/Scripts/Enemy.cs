using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ID { get; set; }

    public int health;
    public int value;

    public void Damage(int damage)
    {
        health -= damage;
    }

    public bool HasHealthLeft()
    {
        return health > 0;
    }

    private void OnDestroy()
    {
        var gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        gameHandler.EnemyDestroyed(ID, value);
    }
}