using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserSpeed;
    public int laserDamage;
    private Vector2 _position;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _position, laserSpeed * Time.deltaTime);
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

    public void Setup(Vector2 position)
    {
        _position = position;
    }
}