using System;
using Unity.VisualScripting;
using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{
    public event Action LastWaypointReached;

    public Waypoint CurrentWaypoint
    {
        get => currentWaypoint;
        set => currentWaypoint = value;
    }

    [SerializeField]
    private Waypoint currentWaypoint;
    [SerializeField]
    private float speed = 10.0f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, currentWaypoint.transform.position) < 0.0001f)
        { 
            currentWaypoint = currentWaypoint.Next;
            
            if (currentWaypoint is null)
            {
                RaiseLastWaypointReached();
                Destroy(gameObject);
                return;
            }
        }

        transform.position =
            Vector2.MoveTowards(transform.position, currentWaypoint.transform.position, speed * Time.deltaTime);
    }

    private void RaiseLastWaypointReached()
    {
        LastWaypointReached?.Invoke();
    }
}