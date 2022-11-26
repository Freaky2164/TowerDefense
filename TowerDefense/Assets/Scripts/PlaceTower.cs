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

    private Vector2 relativePos;
    private Vector2 _mousePos;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _canMove = false;
        _dragging = false;
        _hasToClone = false;
        var test = _collider.transform.position;
        relativePos = new Vector2(test.x, test.y);
        
        var position = transform.position;
        _oldPosition = new Vector3(position.x, position.y , position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            if ((relativePos - mousePos).magnitude < 0.5F)
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
            transform.position = new Vector3(0, 0, 0);
            _mousePos = mousePos;
        }
        if (Input.GetMouseButtonUp(0) || Input.touchCount <= 0)
        {
            if (_hasToClone)
            {
                if ((relativePos - mousePos).magnitude > 0.75F)
                { 
                    Instantiate(tower, _mousePos, transform.rotation); 
                }
                _hasToClone = false;
            }
            
            transform.position = _oldPosition;
            _canMove = false;
            _dragging = false;
        }
    }
}