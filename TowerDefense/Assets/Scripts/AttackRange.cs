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
    
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")){
        gameObject.GetComponent<Collider>().enabled = false;
        var laser = Instantiate(laserObject, cannon.transform.position, other.gameObject.transform.rotation);
        laser.Setup((other.gameObject.transform.position));
        yield return new WaitForSeconds (1);
        gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}