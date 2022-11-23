using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

class PlaceTower : MonoBehaviour
{
    public GameObject tower;
    
    private Collider2D _collider;
    private bool _canMove;
    private bool _dragging;
    private Vector3 _oldPosition;
    private bool _hasToClone;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _canMove = false;
        _dragging = false;
        _hasToClone = false;
        
        var position = transform.position;
        _oldPosition = new Vector3(position.x, position.y , position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            if (_collider == Physics2D.OverlapPoint(mousePos))
            {
                _canMove = true;
            }
            else
            {
                _canMove = false;
            }
            if (_canMove)
            {
                _dragging = true;
                _hasToClone = true;
            }
        }
        if (_dragging)
        {
            transform.position = mousePos;
        }
        if (Input.GetMouseButtonUp(0) || Input.touchCount <= 0)
        {
            _canMove = false;
            _dragging = false;
            if (_hasToClone)
            { 
                Instantiate(tower, transform.position, transform.rotation);
                transform.position = _oldPosition;
                _hasToClone = false;
            }
        }
    }
}