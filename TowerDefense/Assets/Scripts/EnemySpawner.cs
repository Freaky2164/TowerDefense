using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrf;
    private float spawnTimer = 2;

    // Update is called once per frame
    void Update()
    {
        if(TimerFinished()){
            var enemy = Instantiate(enemyPrf, transform.position, enemyPrf.transform.rotation);
            enemy.GetComponent<FollowWP>().currentWP = GetComponent<Waypoint>();
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
}
