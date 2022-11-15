using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserSpeed;
    public int laserDamage;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, position, laserSpeed * Time.deltaTime);
        
    }

    public void setup(Vector2 position){
        this.position = position;
    }


    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.damage(laserDamage);
                if (!enemy.hasHealthLeft())
                {
                    Destroy(other.gameObject);
                }
            }
            Destroy(gameObject);
        }

    }

}
