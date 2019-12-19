using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;   // Float so that our vector math is simpler

    private Transform _targetWaypoint;
    private int _waypointIndex = 0;

    public string Name => gameObject.name;

    // Start is called before the first frame update
    private void Start()
    {
        ////Debug.Log($"{Name} | Assign initial Target Waypoint");
        _targetWaypoint = Waypoints.Points[_waypointIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        if (_waypointIndex >= Waypoints.Points.Length)
        {
            // Destroy the 'object' that this script is bound to
            ////Debug.Log($"{Name} | Destroying game object");
            Destroy(gameObject);

            return;
        }

        ////Debug.Log("Moving to Target Waypoint");
        MoveToTargetWaypoint();

        if (Vector3.Distance(_targetWaypoint.position, gameObject.transform.position) <= 0.2f)
        {
            AssignNextTargetWaypoint();
        }
    }

    private void MoveToTargetWaypoint()
    {
        var direction = _targetWaypoint.position - gameObject.transform.position;

        gameObject.transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.World);
    }

    private void AssignNextTargetWaypoint()
    {
        _waypointIndex++;
        if (_waypointIndex >= Waypoints.Points.Length)
        {
            ////Debug.Log($"{Name} | No more Waypoints to assign");
            return;
        }

        ////Debug.Log($"{Name} | Assigning next Waypoint");
        _targetWaypoint = Waypoints.Points[_waypointIndex];
    }
}
