using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyPrf;
    public int health;
    public int value;
    private int id;

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

    public GameObject getPrefab()
    {
        return this.enemyPrf;
    }

    public void setId(int value)
    {
        this.id = value;
    }

    private void OnDestroy()
    {
        GameHandler gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        gameHandler.enemyDestroyed(id, value);
    }
}
