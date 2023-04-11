using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    public Laser laserObject;
    public float attackSpeed;
    private List<GameObject> _enemys;
    private float _fireCountDown;
    private GameObject _rangeObject;
    private Camera _camera;
    private const float MaxDistance = 0.1f;
    private LayerMask _layerMask;

    public bool CanShoot { get; set; } = false;

    private void Start()
    {
        _camera = Camera.main;
        _enemys = new List<GameObject>();
        _fireCountDown = 0;
        _rangeObject = transform.GetChild(0).gameObject;
        _layerMask = LayerMask.GetMask("Default");
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) { 
            _enemys.Add(other.gameObject);
        }
        yield return null;
    }

    IEnumerator OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) { 
            _enemys.Remove(other.gameObject);
        }
        yield return null; 
    }
    
    
private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition); 
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, MaxDistance, _layerMask);
            
            if (hit.collider == null || hit.collider.gameObject != gameObject) 
            { 
                toggleRangeVisibility(false); 
            }
            else
            {
                toggleRangeVisibility(true);
            }
        }

        if (!CanShoot)
        {
            return;
        }
        if (_enemys.Count == 0)
        {
            _fireCountDown--;
            return;
        }

        if (_fireCountDown <= 0)
        {
            var laser = Instantiate(laserObject, transform.position, Quaternion.identity);
            laser.Setup(_enemys[0]);
            _fireCountDown = 1F / attackSpeed;
            return;
        }

        _fireCountDown -= Time.deltaTime;
    }


private void toggleRangeVisibility(bool set)
{
    _rangeObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,set ? 0.1F : 0.0F);
}
}

