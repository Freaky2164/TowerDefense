using Audio;
using GameHandling;
using UnityEngine;
using UnityEngine.Splines;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private FollowSpline _followSpline;

        [SerializeField]
        private int health;

        [SerializeField]
        private int value;

        [SerializeField]
        private int damage;

        private Sound _dieSound;

        public Sound DieSound => _dieSound;
        
        public FollowSpline FollowSpline
        {
            get => _followSpline ??= GetComponent<FollowSpline>();
            private set => _followSpline = value;
        }

        public SplineContainer Path
        {
            get => FollowSpline.Path;
            set => FollowSpline.Path = value;
        }

        private void Start()
        {
            FollowSpline.EndReached += OnEndReached;
            _dieSound = Sound.EnemyDestroyed;
        }

        public void Damage(int damageTaken)
        {
            health -= damageTaken;
        }

        public bool HasHealthLeft()
        {
            return health > 0;
        }

        private void OnDestroy()
        {
            GameHandler.I.Enemies.RaiseEnemyDestroyed(this);
        }

        private void OnEndReached()
        {
            GameHandler.I.Player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}