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
    private List<Collider2D> overlappingCollider;
    private bool canPlace = true;

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
            overlappingCollider = getOverlappingCollider();
            if (overlappingCollider.Count != 0)
            {
                canPlace = false;
                var kind = _draggingTower.transform.GetChild(0).gameObject;
                kind.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.1F);
            }
            else 
            {
                if (!canPlace) 
                {
                    canPlace = true;
                    var kind = _draggingTower.transform.GetChild(0).gameObject;
                    kind.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0.1F); 
                }
            }
            _draggingTower.transform.position = mousePos;
        }

        if (!Input.GetMouseButtonUp(0) && Input.touchCount > 0) return;
        if (_hasToClone)
        {
            if ((_relativePos - mousePos).magnitude > 0.75F)
            {
                List<Collider2D> results = getOverlappingCollider();
                if (results.Count == 0)
                { 
                    if (_gameHandler.FinancialSystem.TryBuy(300))
                    {
                        var towerToPlace = Instantiate(tower, _draggingTower.transform.position, _draggingTower.transform.rotation);
                        towerToPlace.GetComponentInChildren<AttackRange>().CanShoot = true;
                    }
                }
            }
        }
        Destroy(_draggingTower);
        _dragging = false;
        _hasToClone = false;
    }

    private List<Collider2D> getOverlappingCollider()
    {
        Collider2D coll = _draggingTower.GetComponent<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        Physics2D.OverlapCollider(coll, filter, results);
        return results.FindAll(collider1 => !collider1.gameObject.CompareTag("AttackRange"));
    }
}