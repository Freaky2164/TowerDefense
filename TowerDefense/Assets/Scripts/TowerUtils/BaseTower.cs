using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using GameHandling;
using TowerUtils.Upgrades;
using UnityEngine;

namespace TowerUtils
{
    public abstract class BaseTower : MonoBehaviour
    {
        private const float MaxDistance = 0.1f;
        public Projectile projectile;
        public float attackSpeed;
        private Camera _camera;
        private List<GameObject> _enemies;
        private float _fireCountDown;
        private LayerMask _layerMask;
        private GameObject _rangeObject;
        private SpriteRenderer _spriteRenderer;
        protected Sound ShotSound; 
        protected UpgradeTree upgradeTree;

        public void SetNewLeftUpgrade(UpgradeTree tree)
        {
            upgradeTree.LeftNextUpgrade = tree;
        }
        
        public void SetNewRightUpgrade(UpgradeTree tree)
        {
            upgradeTree.RightNextUpgrade = tree;
        }

        public bool CanShoot { get; set; } = false;

        protected abstract void Initialize();

        private void Start()
        {
            _camera = Camera.main;
            _enemies = new List<GameObject>();
            _fireCountDown = 0;
            _layerMask = LayerMask.GetMask("Default");
            _rangeObject = transform.GetChild(0).gameObject;
            _spriteRenderer = _rangeObject.GetComponent<SpriteRenderer>();
            Initialize();
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
                AudioHandler.I.Play(ShotSound);
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
                var uiHit = Physics2D.Raycast(mousePosition, Vector2.zero, MaxDistance, LayerMask.GetMask("UI") );
                if (uiHit.collider != null)
                {
                    return;
                }

                if (hit.collider == null || hit.collider.gameObject != gameObject)
                {
                    _spriteRenderer.color = new Color(255, 255, 255, 0.0F);
                    if (hit.collider != null && !hit.collider.gameObject.CompareTag("Tower"))
                    { 
                        ToggleUpgradeMenu(false);
                    }
                }
                else
                {
                    _spriteRenderer.color = new Color(255, 255, 255, 0.1F);
                    ToggleUpgradeMenu(true);
                }
            }
        }

        private void ToggleUpgradeMenu(bool toggle)
        {
            if (toggle)
            { 
                GameHandler.I.upgradeMenu.SetTowerAndProjectile(upgradeTree, this, projectile);
                return;
            }
            GameHandler.I.upgradeMenu.SetTowerAndProjectile(null, null, null);
        }
    }
}