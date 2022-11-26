using System;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public Waypoint currentWP;

    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, currentWP.transform.position) < 0.0001f)
        {
            GameObject currentWPGameObject = currentWP.nextWaypoint;
            if (currentWPGameObject == null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                currentWP = currentWP.nextWaypoint.GetComponent<Waypoint>();
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, currentWP.transform.position, speed * Time.deltaTime);
    }
}
