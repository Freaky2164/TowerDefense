using UnityEngine;

namespace WaypointSystem
{
    public class Waypoint : MonoBehaviour
    {
        private Waypoint _next;

        [SerializeField]
        private GameObject nextWaypoint;

        public Waypoint Next => _next ??= nextWaypoint ? nextWaypoint.GetComponent<Waypoint>() : null;

        public bool IsLast => _next is null;
        public Vector3 Pos => transform.position;
    }
}