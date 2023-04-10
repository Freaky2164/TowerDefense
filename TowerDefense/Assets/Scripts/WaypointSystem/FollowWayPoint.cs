using System;
using UnityEngine;

namespace WaypointSystem
{
    public class FollowWayPoint : MonoBehaviour
    {
        private const float DistanceThreshold = 0.0001f;
        public event Action LastWaypointReached;

        public Waypoint CurrentWaypoint
        {
            get => currentWaypoint;
            set => currentWaypoint = value;
        }
        
        private Vector3 Pos
        {
            get => transform.position;
            set => transform.position = value;
        }

        [SerializeField]
        private Waypoint currentWaypoint;
        [SerializeField]
        private float speed = 10.0f;

        // Update is called once per frame
        private void Update()
        {
            var hasReachedWaypoint = Vector2.Distance(Pos, CurrentWaypoint.Pos) < DistanceThreshold;
            if (hasReachedWaypoint)
            {
                if (!CurrentWaypoint.IsLast)
                {
                    CurrentWaypoint = CurrentWaypoint.Next;
                    return;
                }

                RaiseLastWaypointReached();
                Destroy(gameObject);
                return;
            }

            Pos = Vector2.MoveTowards(Pos, CurrentWaypoint.Pos, speed * Time.deltaTime);
        }

        private void RaiseLastWaypointReached()
        {
            LastWaypointReached?.Invoke();
        }
    }
}