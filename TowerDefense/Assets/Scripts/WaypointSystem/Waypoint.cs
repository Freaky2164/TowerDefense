using UnityEngine;

namespace WaypointSystem
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField]
        private Waypoint nextWaypoint;

        public Waypoint Next => nextWaypoint;
        
        public bool IsLast => nextWaypoint is null;
        public Vector3 Pos => transform.position;
    }
}