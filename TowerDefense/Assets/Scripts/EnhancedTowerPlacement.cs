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
    private List<Collider2D> overlappingCollider;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _dragging = false;
    }

    private void Update()
    {
        if (!_dragging) return;
        if (_draggingTower.IsUnityNull())
        { 
            _draggingTower = Instantiate(tower, transform.position, transform.rotation);
        }
        List<Collider2D> overlappingCollider = getOverlappingCollider();
            if (Input.GetMouseButton(0) || (Input.touchCount == 0))
            {
                if (overlappingCollider.Count == 0)
                { 
                    if (_gameHandler.FinancialSystem.TryBuy(300))
                    {
                        var towerToPlace = Instantiate(tower, _draggingTower.transform.position, _draggingTower.transform.rotation);
                        towerToPlace.GetComponentInChildren<AttackRange>().CanShoot = true;
                        Destroy(_draggingTower);
                        _dragging = false;
                    }
                }
            }
            if (overlappingCollider.Count != 0)
            {
                var kind = _draggingTower.transform.GetChild(0).gameObject;
                kind.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.1F);
            }else
            {
                    var kind = _draggingTower.transform.GetChild(0).gameObject;
                    kind.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0.1F); 
            }
            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _draggingTower.transform.position = mousePos;
    }

    public void ToogleDragging()
    {
        _dragging = !_dragging;
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