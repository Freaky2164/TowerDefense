using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserSpeed;
    public int laserDamage;
    private Vector2 position;
    private bool isNotMoving = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, position, laserSpeed * Time.deltaTime);
        StartCoroutine(CheckMoving());
        if(isNotMoving)
        {
           Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag($"Enemy")) return;
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(laserDamage);
            if (!enemy.HasHealthLeft())
            {
                Destroy(other.gameObject);
            }
        }

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator CheckMoving()
     {
         Vector3 startPos = transform.position;
         yield return new WaitForSeconds(0.3f);
         Vector3 finalPos = transform.position;
         if(startPos == finalPos) isNotMoving = false;
         else isNotMoving = true;
     }

    public void Setup(Vector2 position)
    {
        this.position = position;
    }
}