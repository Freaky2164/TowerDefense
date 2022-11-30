using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject cannon;
    public Laser laserObject;
    public float attackSpeed;
    private float _spawnTimer;

    private Collider _collider;

    // Start is called before the first frame update
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _spawnTimer = attackSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimerFinished())
        {
            _collider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Enemy")) return;
        GetComponent<Collider>().enabled = false;
        var laser = Instantiate(laserObject, cannon.transform.position, other.gameObject.transform.rotation);
        laser.Setup((other.gameObject.transform.position));
    }

    private bool TimerFinished()
    {
        _spawnTimer -= Time.deltaTime;
        if (!(_spawnTimer <= 0)) return false;
        _spawnTimer = attackSpeed;
        return true;
    }
}