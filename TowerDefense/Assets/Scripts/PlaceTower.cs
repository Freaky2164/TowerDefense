using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

class PlaceTower : MonoBehaviour
{
    public GameObject tower;

    private Camera _camera;
    private Collider2D _collider;
    private GameHandler _gameHandler;
    private Vector2 _mousePos;
    private Vector2 _relativePos;
    private Vector3 _oldPosition;
    private bool _canMove;
    private bool _dragging;
    private bool _hasToClone;

    private void Start()
    {
        _camera = Camera.main;
        _gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        _collider = GetComponent<Collider2D>();
        _canMove = false;
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
            _canMove = (_relativePos - mousePos).magnitude < 0.5F;
            if (_canMove)
            {
                _dragging = true;
                _hasToClone = true;
            }
        }

        if (_dragging)
        {
            transform.position = mousePos;
            _mousePos = mousePos;
        }

        if (!Input.GetMouseButtonUp(0) && Input.touchCount > 0) return;
        if (_hasToClone)
        {
            if ((_relativePos - mousePos).magnitude > 0.75F)
            {
                if (_gameHandler.FinancialSystem.TryBuy(300))
                {
                    Instantiate(tower, _mousePos, transform.rotation);
                }
            }

            _hasToClone = false;
        }

        transform.position = _oldPosition;
        _canMove = false;
        _dragging = false;
    }
}