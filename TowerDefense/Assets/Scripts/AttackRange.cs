using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject tower;
    public Laser laserObject;
    public float attackSpeed;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")) {
            gameObject.GetComponent<Collider>().enabled = false;
            Vector3 targetPosition = other.gameObject.transform.position;
            Vector3 moveDir = (targetPosition - transform.position).normalized;
            float angle = GetAngleFromVectorFloat(moveDir);
            tower.transform.eulerAngles = new Vector3(0, 0, angle + 270);

            var laser = Instantiate(laserObject, tower.transform.position, Quaternion.identity);
            laser.Setup(targetPosition);
            yield return new WaitForSeconds(1 / attackSpeed);
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}