using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using GameHandling;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerUtils
{
public class Laser : Projectile
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(damage); 
            GameHandler.I.Finances.GainMoney(moneyPerHit);
            if (!enemy.HasHealthLeft())
            {
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
}
