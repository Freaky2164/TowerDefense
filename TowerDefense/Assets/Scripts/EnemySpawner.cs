using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Stack<GameObject> enemies;
    private float spawnTimer = 2;

    void Update()
    {
        if(TimerFinished()) {
            GameObject enemy = enemies.Pop();
            var enemyGameObject = Instantiate(enemy, transform.position, enemy.transform.rotation);
            enemyGameObject.GetComponent<Enemy>().setId(enemies.Count);
            enemyGameObject.GetComponent<FollowWP>().currentWP = GetComponent<Waypoint>();
        }
    }

    bool TimerFinished(){
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0){
            spawnTimer = 2;
            return true;
        }
        else
        {
             return false;
        }
    }

    public void setEnemies(Stack<GameObject> enemies)
    {
        this.enemies = enemies;
    }

    public void setTimer(float timerValue)
    {
        spawnTimer = timerValue;
    }

    public void activate()
    {
        this.enabled = true;
    }

    public void deactivate()
    {
        this.enabled = false;
    }
}
