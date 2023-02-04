using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Laser laserObject;
    public float attackSpeed;
    private List<GameObject> _enemys;
    private float _fireCountDown;

    private void Start()
    {
        _enemys = new List<GameObject>();
        _fireCountDown = 0;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) { 
            _enemys.Add(other.gameObject);
        }
        yield return null;
    }

    IEnumerator OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) { 
            _enemys.Remove(other.gameObject);
        }
        yield return null; 
    }
    
    
private void Update()
    {
        if (_enemys.Count == 0)
        {
            _fireCountDown--;
            return;
        }

        if (_fireCountDown <= 0)
        {
            var laser = Instantiate(laserObject, transform.position, Quaternion.identity);
            laser.Setup(_enemys[0]);
            _fireCountDown = 1F / attackSpeed;
            return;
        }

        _fireCountDown -= Time.deltaTime;
    }
}