using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class PlaceTower : MonoBehaviour
{
    public GameObject tower;

    private Camera _camera;
    private Collider2D _collider;
    private GameHandler _gameHandler;
    
    private Vector2 _relativePos;
    private Vector3 _oldPosition;
    
    private bool _dragging;
    private bool _hasToClone;
    private GameObject _draggingTower;
    private void Start()
    {
        _camera = Camera.main;
        _gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        _collider = GetComponent<Collider2D>();

        _dragging = false;
        _hasToClone = false;
        
        var test = _collider.transform.position;
        _relativePos = new Vector2(test.x, test.y);

        var position = transform.position;
        _oldPosition = new Vector3(position.x, position.y, position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            var canMove = (_relativePos - mousePos).magnitude < 0.5F;
            if (canMove && !_dragging)
            {
                _dragging = true;
                _hasToClone = true;
                _draggingTower = Instantiate(tower, mousePos, transform.rotation);

            }
        }

        if (_dragging)
        {
            _draggingTower.transform.position = mousePos;
        }

        if (!Input.GetMouseButtonUp(0) && Input.touchCount > 0) return;
        if (_hasToClone)
        {
            if ((_relativePos - mousePos).magnitude > 0.75F)
            {
                Collider2D coll = _draggingTower.GetComponent<Collider2D>();
                ContactFilter2D filter = new ContactFilter2D().NoFilter();
                List<Collider2D> results = new List<Collider2D>();
                Physics2D.OverlapCollider(coll, filter, results);
                results = results.FindAll(collider1 => !collider1.gameObject.CompareTag("AttackRange"));
                if (results.Count == 0)
                { 
                    if (_gameHandler.FinancialSystem.TryBuy(300))
                    {
                        Instantiate(tower, _draggingTower.transform.position, _draggingTower.transform.rotation);
                    }
                }
            }
        }
        Destroy(_draggingTower);
        _dragging = false;
        _hasToClone = false;
    }
}