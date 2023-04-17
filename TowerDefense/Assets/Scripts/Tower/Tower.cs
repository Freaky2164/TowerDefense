using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private const float MaxDistance = 0.1f;
    public Laser laserObject;
    public float attackSpeed;
    private Camera _camera;
    private List<GameObject> _enemies;
    private float _fireCountDown;
    private LayerMask _layerMask;
    private GameObject _rangeObject;
    private SpriteRenderer _spriteRenderer;


    public bool CanShoot { get; set; } = false;

    private void Start()
    {
        _camera = Camera.main;
        _enemies = new List<GameObject>();
        _fireCountDown = 0;
        _layerMask = LayerMask.GetMask("Default");
        _rangeObject = transform.GetChild(0).gameObject;
        _spriteRenderer = _rangeObject.GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        ToggleRangeVisibility();
        Shoot();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) _enemies.Add(other.gameObject);
        yield return null;
    }

    private IEnumerator OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) _enemies.Remove(other.gameObject);
        yield return null;
    }

    private void Shoot()
    {
        if (!CanShoot) return;
        if (_enemies.Count == 0)
        {
            _fireCountDown--;
            return;
        }

        if (_fireCountDown <= 0)
        {
            var laser = Instantiate(laserObject, transform.position, Quaternion.identity);
            laser.Setup(_enemies[0]);
            _fireCountDown = 1F / attackSpeed;
            return;
        }

        _fireCountDown -= Time.deltaTime;
    }

    private void ToggleRangeVisibility()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero, MaxDistance, _layerMask);

            if (hit.collider == null || hit.collider.gameObject != gameObject)
                _spriteRenderer.color = new Color(255, 255, 255, 0.0F);
            else
                _spriteRenderer.color = new Color(255, 255, 255, 0.1F);
        }
    }
}