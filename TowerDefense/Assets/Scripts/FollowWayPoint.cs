using System;
using Unity.VisualScripting;
using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{
    public event Action LastWaypointReached; 

    public Waypoint currentWp;
    public float speed = 10.0f;

    // Update is called once per frame
    private void Update()
    {
        var currentWpGameObject = currentWp.nextWaypoint;
        if (Vector2.Distance(transform.position, currentWp.transform.position) < 0.0001f)
        { 
            if (currentWpGameObject.IsUnityNull())
            {
                RaiseLastWaypointReached();
                Destroy(gameObject);
                return;
            }
            currentWp = currentWp.nextWaypoint.GetComponent<Waypoint>();
        }

        transform.position =
            Vector2.MoveTowards(transform.position, currentWp.transform.position, speed * Time.deltaTime);
    }

    private void RaiseLastWaypointReached()
    {
        LastWaypointReached?.Invoke();
    }
}