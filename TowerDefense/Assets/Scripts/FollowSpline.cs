using System;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSpline : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Spline _spline;
    private float _currentOffset;
    private float _splineLength;

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
        IncreaseOffset();
        Move();
    }

    private void Initialize()
    {
        _spline = Path.Spline;
        _splineLength = _spline.GetLength();
    }

    private void IncreaseOffset()
    {
        var newOffset = _currentOffset + speed * Time.deltaTime / _splineLength;
        _currentOffset = newOffset % 1f;
        
        var hasReachedEnd = newOffset > 1f;
        if (hasReachedEnd)
        {
            RaiseEndReached();
        }
    }
        
    private void Move()
    {
        var pos = transform.position;

        var posOnSplineLocal = _spline.EvaluatePosition(_currentOffset);
        var newPos = Path.transform.TransformPoint(posOnSplineLocal);
        transform.position = new Vector3(newPos.x, newPos.y, pos.z);

        var direction = _spline.EvaluateTangent(_currentOffset);
        var upSplineDirection = _spline.EvaluateUpVector(_currentOffset);

        var rot = Quaternion.LookRotation(direction, upSplineDirection);
        var rotation = Quaternion.LookRotation(direction, rot * Vector3.up);
            
        _rb.velocity = rotation * transform.up * speed;
    }

    private void RaiseEndReached()
    {
        EndReached?.Invoke();
    }
}