using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserSpeed;
    public int laserDamage;
    private GameObject _target;
    private Vector3 _moveDir = Vector3.zero;
    private Renderer _renderer;

    private void Start()
    {
        _moveDir = Vector3.zero;
        _renderer = GetComponent<Renderer>();
    }


    private void Update()
    {
        if (!_renderer.isVisible)
        {
            Destroy(this);
        }

        if (_target.IsDestroyed())
        {
            transform.position += _moveDir * (laserSpeed * Time.deltaTime);
            return;
        }
        Move();
    }

    private void Move()
    {
        var transform1 = transform;
        var position = transform1.position;
        _moveDir = (_target.transform.position - position).normalized;
        position += _moveDir * (laserSpeed * Time.deltaTime);
        transform1.position = position;
        float angle = GetAngleFromVectorFloat(_moveDir);
        transform.eulerAngles = new Vector3(0, 0, angle + 90);
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        var n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(laserDamage); 
            GameHandler.I.FinancialSystem.GainMoney(20);
            if (!enemy.HasHealthLeft())
            {
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Setup(GameObject target)
    {
        _target = target;
    }
}