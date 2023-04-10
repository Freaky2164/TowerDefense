using UnityEditor;
using UnityEngine;

namespace WaypointSystem
{
    public abstract class WaypointGizmos
    {
        private static readonly Color WaypointColor = Color.red;
        private static readonly Color PathColor = Color.yellow;
        private static readonly Color DirectionColor = Color.white;
        
        private const float Radius = 0.2f;

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable, typeof(Waypoint))]   
        public static void DrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType)
        {
            DrawPath(waypoint);

            DrawWaypoint(waypoint);
        }

        private static void DrawWaypoint(Waypoint waypoint)
        {
            var pos = waypoint.Pos;
            
            Gizmos.color = WaypointColor;
            Gizmos.DrawSphere(pos, Radius);

            var offset = waypoint.transform.up * Radius;
            
            Gizmos.color = DirectionColor;
            Gizmos.DrawLine(pos, pos + offset);
        }

        private static void DrawPath(Waypoint waypoint)
        {
            if (waypoint.Next == null)
            {
                return;
            }
            
            var start = waypoint.Pos;
            var end = waypoint.Next.Pos;

            Gizmos.color = PathColor;
            Gizmos.DrawLine(start, end);
        }
    }
}