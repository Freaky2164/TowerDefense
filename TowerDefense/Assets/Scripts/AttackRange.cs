using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{

    public GameObject cannon;
    public Laser laserObject;
    public float attackspeed;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = attackspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerFinished()){
            GetComponent<Collider>().enabled = true; 
       }
    }

    private void OnTriggerEnter(Collider other) {
        GetComponent<Collider>().enabled = false;
        Laser laser = (Laser)Instantiate(laserObject, cannon.transform.position, other.gameObject.transform.rotation);
        laser.setup((other.gameObject.transform.position));
        
    }


    private bool TimerFinished(){
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0){
           spawnTimer = attackspeed;
            return true;
        }
        else
        {
            return false;
        }
    }
}
