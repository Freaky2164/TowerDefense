using System;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSpline : MonoBehaviour
{
    private const float DistanceThreshold = 0.1f;

    private Rigidbody2D _rb;
    private NativeSpline _spline;
    private Vector3 _end;

    [SerializeField]
    private SplineContainer path;

    [SerializeField]
    private float speed = 10f;

    public SplineContainer Path
    {
        get => path;
        set
        {
            path = value;
            Initialize();
        }
    }

    public event Action EndReached;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Initialize();
    }

    private void Update()
    {
        Move();
        CheckEndReached();
    }

    private void Initialize()
    {
        var localToWorldMatrix = Path.transform.localToWorldMatrix;
        _spline = new NativeSpline(Path.Spline, localToWorldMatrix, Allocator.Persistent);
        var last = Path.Spline.Knots.Last();
        _end = Path.transform.TransformPoint(last.Position);
    }

    private void CheckEndReached()
    {        
        var hasReachedEnd = Vector2.Distance(transform.position, _end) < DistanceThreshold;
        if (hasReachedEnd)
        {
            RaiseEndReached();
        }
    }
        
    private void Move()
    {
        var pos = transform.position;
            
        SplineUtility.GetNearestPoint(_spline, pos, out var newPos, out var t);
        transform.position = new Vector3(newPos.x, newPos.y, pos.z);

        var forward = Vector3.Normalize(_spline.EvaluateTangent(t));
        var up = _spline.EvaluateUpVector(t);

        var axisRemappedRotation = Quaternion.Inverse(Quaternion.LookRotation(Vector3.up, Vector3.forward));

        var rotation = Quaternion.LookRotation(forward, up) * axisRemappedRotation;
            
        _rb.velocity = rotation * transform.up * speed;
    }

    private void RaiseEndReached()
    {
        EndReached?.Invoke();
    }
}