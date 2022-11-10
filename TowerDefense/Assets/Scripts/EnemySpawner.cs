using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private float spawnTimer = 2;

    // Update is called once per frame
    void Update()
    {
        if(TimerFinished()){
            Vector2 spawnPos = new Vector2(-7,Random.Range(-1,1));
            Instantiate(enemy, spawnPos,enemy.transform.rotation);
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
