using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private GameObject nextWaypoint;
    
    public Waypoint Next { get; private set; }

    private void Start()
    {
        Next = nextWaypoint?.GetComponent<Waypoint>();
    }
}