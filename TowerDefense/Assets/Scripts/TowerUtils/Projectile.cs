using Unity.VisualScripting;
using UnityEngine;

namespace TowerUtils
{
    public abstract class Projectile : MonoBehaviour
    {
        public int laserSpeed;
        public int laserDamage;
        private GameObject _target;
        private Vector3 _moveDir = Vector3.zero;
        private Renderer _renderer;

        protected virtual void Initialize()
        {
        }
        
        private void Start()
        {
            _moveDir = Vector3.zero;
            _renderer = GetComponent<Renderer>();
            Initialize();
        }


        private void Update()
        {
            if (!_renderer.isVisible)
            {
                Destroy(this);
            }

            if (_target.IsDestroyed())
            {
                transform.position += _moveDir * (laserSpeed * Time.deltaTime);
                return;
            }
            Move();
        }
        
        private void Move()
        {
            var transform1 = transform;
            var position = transform1.position;
            _moveDir = (_target.transform.position - position).normalized;
            position += _moveDir * (laserSpeed * Time.deltaTime);
            transform1.position = position;
            float angle = GetAngleFromVectorFloat(_moveDir);
            transform.eulerAngles = new Vector3(0, 0, angle + 90);
        }

        private static float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            var n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public void Setup(GameObject target)
        {
            _target = target;
        }
    }
}