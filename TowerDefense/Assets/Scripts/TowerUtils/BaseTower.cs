using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using TowerUtils.Upgrades;
using UnityEngine;

namespace TowerUtils
{
    public class BaseTower : MonoBehaviour
    {
        private const float MaxDistance = 0.1f;
        public Projectile projectile;
        private Sound _shotSound;
        public float attackSpeed;
        private Camera _camera;
        private List<GameObject> _enemies;
        private float _fireCountDown;
        private LayerMask _layerMask;
        private GameObject _rangeObject;
        private SpriteRenderer _spriteRenderer;
        public GameObject upgradeMenu;
        private UpgradeMenu _upgradeMenuScript;


        public bool CanShoot { get; set; } = false;
        
        protected virtual void Initialize()
        {
        }

        private void Start()
        {
            _camera = Camera.main;
            _enemies = new List<GameObject>();
            _fireCountDown = 0;
            _layerMask = LayerMask.GetMask("Default");
            _rangeObject = transform.GetChild(0).gameObject;
            _spriteRenderer = _rangeObject.GetComponent<SpriteRenderer>();
            var test = GameObject.FindGameObjectWithTag("Canvas");
            upgradeMenu = Instantiate(upgradeMenu, test.transform, false);
            // ToggleUpgradeMenu(false);
            _upgradeMenuScript = upgradeMenu.GetComponent<UpgradeMenu>();
            _shotSound = Sound.CanonTowerShot;
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
                var laser = Instantiate(projectile, transform.position, Quaternion.identity);
                laser.Setup(_enemies[0]);
                _fireCountDown = 1F / attackSpeed;
                AudioHandler.I.Play(_shotSound);
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
                {
                    _spriteRenderer.color = new Color(255, 255, 255, 0.0F); 
                    // ToggleUpgradeMenu(false);
                }
                else
                {
                    _spriteRenderer.color = new Color(255, 255, 255, 0.1F);
                    // ToggleUpgradeMenu(true);
                }
            }
        }

        private void ToggleUpgradeMenu(bool toggle)
        {
            _upgradeMenuScript.SetTowerAndProjectile(this, projectile);
            upgradeMenu.SetActive(toggle);
        }

        private void OnDestroy()
        {
            Destroy(upgradeMenu);
        }
    }
}