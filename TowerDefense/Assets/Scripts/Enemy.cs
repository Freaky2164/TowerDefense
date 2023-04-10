using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointSystem;

public class Enemy : MonoBehaviour
{
    private FollowWayPoint followWayPoint;
    
    public int ID { get; set; }

    public int health;
    public int value;
    public int damage;

    private void Start()
    {
        followWayPoint = GetComponent<FollowWayPoint>();
        followWayPoint.LastWaypointReached += OnLastWaypointReached;
    }

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

    private void OnLastWaypointReached()
    {
        GameHandler.i.Player.TakeDamage(damage);
    }
}