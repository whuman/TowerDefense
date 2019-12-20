using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed = 10f;   // Float so that our vector math is simpler
    public int Life = 100;

    private Transform _targetWaypoint;
    private int _waypointIndex = 0;

    public void TakeDamage(int damage)
    {
        Life -= damage;

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _targetWaypoint = Waypoints.Points[_waypointIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        if (_waypointIndex >= Waypoints.Points.Length)
        {
            // Destroy the 'object' that this script is bound to
            Destroy(gameObject);

            return;
        }

        MoveToTargetWaypoint();

        if (Vector3.Distance(_targetWaypoint.position, gameObject.transform.position) <= 0.2f)
        {
            AssignNextTargetWaypoint();
        }
    }

    private void MoveToTargetWaypoint()
    {
        // Direction from gameObject to target Object
        var direction = _targetWaypoint.position - gameObject.transform.position;

        gameObject.transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.World);
    }

    private void AssignNextTargetWaypoint()
    {
        _waypointIndex++;
        if (_waypointIndex >= Waypoints.Points.Length)
        {
            return;
        }

        _targetWaypoint = Waypoints.Points[_waypointIndex];
    }
}
