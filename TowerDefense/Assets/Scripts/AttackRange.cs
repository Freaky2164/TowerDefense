using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Laser laserObject;
    public float attackSpeed;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) { 
            gameObject.GetComponent<Collider2D>().enabled = false;
            Vector3 targetPosition = other.gameObject.transform.position;

            var laser = Instantiate(laserObject, transform.position, Quaternion.identity);
            laser.Setup(targetPosition);
            yield return new WaitForSeconds(1 / attackSpeed);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}