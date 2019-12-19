using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float Range = 10f;

    [Header("Unity Setup Fields")]
    public string TargetTag = "Enemy";
    public Transform PartToRotate;
    public float TurnSpeed = 10f;

    private Transform _target;

    // Start is called before the first frame update
    private void Start()
    {
        // Call the UpdateTarget method every 0.5s
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_target == null || PartToRotate == null)
        {
            return;
        }

        var targetDirection = _target.position - gameObject.transform.position;
        var lookRotation = Quaternion.LookRotation(targetDirection);

        // Smooth the transition via Lerp function
        var rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;    // From turret to target

        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        // Clear current target
        _target = null;

        GameObject closestEnemy = null;
        var enemies = GameObject.FindGameObjectsWithTag(TargetTag);

        var currentPosition = gameObject.transform.position;
        var shortestDistance = Mathf.Infinity;
        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= Range)
        {
            _target = closestEnemy.transform;
        }
    }

    // Display Range around turrets
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, Range);
    }
}
