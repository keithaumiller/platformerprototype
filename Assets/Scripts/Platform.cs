using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Settings")]
    public bool isMoving = false;
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public bool isOneWay = false;
    
    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    
    void Start()
    {
        if (isMoving && waypoints.Length < 2)
        {
            Debug.LogWarning("Moving platform needs at least 2 waypoints!");
            isMoving = false;
        }
    }
    
    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }
    
    private void MovePlatform()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (isOneWay)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                if (movingForward)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        currentWaypointIndex = waypoints.Length - 2;
                        movingForward = false;
                    }
                }
                else
                {
                    currentWaypointIndex--;
                    if (currentWaypointIndex < 0)
                    {
                        currentWaypointIndex = 1;
                        movingForward = true;
                    }
                }
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    
    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;
        
        Gizmos.color = Color.blue;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null) continue;
            
            Gizmos.DrawWireSphere(waypoints[i].position, 0.3f);
            
            if (i < waypoints.Length - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
            else if (!isOneWay)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[0].position);
            }
        }
    }
}