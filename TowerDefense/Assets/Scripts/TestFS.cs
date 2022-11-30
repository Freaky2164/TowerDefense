using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFs : MonoBehaviour
{
    private FinancialSystem _fs;
    private float _spawnTimer = 2;

    private void Start()
    {
        _fs = new FinancialSystem(500);
    }

    private void Update()
    {
        if (TimerFinished())
        {
            _fs.GainMoney(400);
        }
    }

    private bool TimerFinished()
    {
        _spawnTimer -= Time.deltaTime;
        if (!(_spawnTimer <= 0)) return false;
        _spawnTimer = 2;
        return true;
    }
}