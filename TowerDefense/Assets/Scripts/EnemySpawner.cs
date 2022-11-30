using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _spawnTimer = 2;
    private Waypoint _waypoint;
    public Stack<GameObject> Enemies { get; set; }

    private void Start()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        if (!TimerFinished()) return;
        if (Enemies.IsUnityNull())
        {
            Deactivate();
        }
        var enemy = Enemies.Pop();
        var enemyGameObject = Instantiate(enemy, transform.position, enemy.transform.rotation);
        enemyGameObject.GetComponent<Enemy>().ID = Enemies.Count;
        enemyGameObject.GetComponent<FollowWayPoint>().currentWp = _waypoint;
    }

    private bool TimerFinished()
    {
        _spawnTimer -= Time.deltaTime;
        if (!(_spawnTimer <= 0)) return false;
        _spawnTimer = 2;
        return true;
    }
    public void Activate()
    {
        enabled = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }
}