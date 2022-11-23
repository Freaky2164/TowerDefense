using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFS : MonoBehaviour
{
    private FinancialSystem fs;
    private float spawnTimer = 2;

    void Start()
    {
        fs = new FinancialSystem(500);
    }

    void Update()
    {
        if (TimerFinished())
        {
            fs.gainMoney(400);
        }
    }
    bool TimerFinished()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = 2;
            return true;
        }
        else
        {
            return false;
        }
    }
}
