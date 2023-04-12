using UnityEngine;
using UnityEngine.Splines;

namespace WaypointSystem
{
    public class FollowSpline : MonoBehaviour
    {
        [SerializeField]
        private SplineContainer path;

        [SerializeField]
        private float speed = 10f;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var native = new NativeSpline(path.Spline);
            var pos = transform.position;
            
            SplineUtility.GetNearestPoint(native, pos, out var newPos, out var t);
            transform.position = new Vector3(newPos.x, newPos.y, pos.z);

            var forward = Vector3.Normalize(path.EvaluateTangent(t));
            var up = path.EvaluateUpVector(t);

            var axisRemappedRotation = Quaternion.Inverse(Quaternion.LookRotation(Vector3.up, Vector3.forward));

            var rotation = Quaternion.LookRotation(forward, up) * axisRemappedRotation;
            
            _rb.velocity = rotation * transform.up * speed;
        }
    }
}