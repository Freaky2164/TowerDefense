using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserSpeed;
    public int laserDamage;
    private Vector3 targetPosition;
    private bool isNotMoving = false;

    private void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        transform.position += moveDir * laserSpeed * Time.deltaTime;
        float angle = GetAngleFromVectorFloat(moveDir);
        transform.eulerAngles = new Vector3(0, 0, angle + 90);
        StartCoroutine(CheckMoving());
        if(isNotMoving)
        {
           Destroy(gameObject);
        }
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
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

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}