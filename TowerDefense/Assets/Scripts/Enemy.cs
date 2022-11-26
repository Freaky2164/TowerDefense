using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int value;

    public void damage(int damage)
    {
        health = health - damage;
    }

    public bool hasHealthLeft()
    {
        if (health <= 0)
        {
            return false;
        }
        return true;
    }

    private void OnDestroy()
    {
        GameHandler gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        gameHandler.enemyDestroyed(value);
    }
}
