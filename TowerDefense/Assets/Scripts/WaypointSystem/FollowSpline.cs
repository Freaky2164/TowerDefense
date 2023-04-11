using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace WaypointSystem
{
    public class FollowSpline : MonoBehaviour
    {
        [SerializeField]
        private SplineContainer path;

        private float speed = 5f;

        private Vector3 Pos
        {
            get => transform.position;
            set => transform.position = value;
        }

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            SplineUtility.GetNearestPoint(path.Spline, Pos, out var nearest, out var t);
            Pos = nearest;

            var forward = path.EvaluateTangent(t);
            var up = path.EvaluateUpVector(t);

            transform.rotation = Quaternion.LookRotation(up, forward);
            
            rb.velocity = speed * transform.up;
        }
    }
}