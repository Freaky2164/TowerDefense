using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnhancedTowerPlacement : MonoBehaviour
{
    public GameObject tower;
    private GameObject _draggingTower;
    private GameHandler _gameHandler;
    private bool _dragging;
    private List<Collider2D> _overlappingCollider;
    private Camera _camera;
    private bool _canPlace = true;
    private Collider2D _draggingTowerCollider;
    private SpriteRenderer _draggingTowerAttackRangeRenderer;

    private void Start()
    {
        _camera = Camera.main;
        _gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        _dragging = false;
    }

    private void Update()
    {
        if (!_dragging) return;
        if (_draggingTower.IsUnityNull())
        { 
            _draggingTower = Instantiate(tower, transform.position, transform.rotation);
            _draggingTowerCollider = _draggingTower.GetComponent<Collider2D>();
            _draggingTowerAttackRangeRenderer = _draggingTower.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        }
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _draggingTower.transform.position = mousePos;
        _overlappingCollider = GetOverlappingCollider();
        if (_overlappingCollider.Count != 0)
        {
            _canPlace = false;
            _draggingTowerAttackRangeRenderer.color = new Color(255, 0, 0, 0.1F);
        }
        else 
        {
            if (!_canPlace) 
            {
                _canPlace = true;
                _draggingTowerAttackRangeRenderer.color = new Color(255,255,255,0.1F); 
            }
        }
        if (!Input.GetMouseButtonUp(0) && Input.touchCount > 0) return;
        if (_canPlace)
        {
            if (!_gameHandler.FinancialSystem.TryBuy(300)) return;
            var towerToPlace = Instantiate(tower, _draggingTower.transform.position, _draggingTower.transform.rotation);
            towerToPlace.GetComponentInChildren<Tower>().CanShoot = true;
        }
        Destroy(_draggingTower);
        _dragging = false;
    }

    public void OnClick()
    {
        _dragging = true;
    }

    private List<Collider2D> GetOverlappingCollider()
    {
        var filter = new ContactFilter2D().NoFilter();
        var results = new List<Collider2D>();
        Physics2D.OverlapCollider(_draggingTowerCollider, filter, results);
        return results.FindAll(collider1 => !collider1.gameObject.CompareTag("AttackRange"));
    }
}