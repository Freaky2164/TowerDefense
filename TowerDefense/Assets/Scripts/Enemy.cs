using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

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
}
