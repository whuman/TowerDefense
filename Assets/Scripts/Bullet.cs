using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    public int Damage = 10;

    [Header("Unity Setup Fields")]
    public GameObject ImpactEffectPrefab;

    private Transform _target;
    private Enemy _targetEnemy;
    private float _speed = 50f;

    public void AssignTarget(Transform target, float speed)
    {
        _target = target;
        _targetEnemy = target.GetComponent<Enemy>();    // Assign it here to save lookup time on Hit logic
        _speed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);

            return;
        }

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        // Direction from gameObject to target Object
        var direction = _target.position - gameObject.transform.position;

        // we cannot just move '_speed * Time.deltaTime' distance as this may take us past the
        // actual point that we are trying to get to.
        var distanceToTravel = _speed * Time.deltaTime;

        // We have 'technically' hit our target
        if (direction.magnitude <= distanceToTravel)
        {
            distanceToTravel = direction.magnitude;

            // Do something to the target that we've hit
            HitTarget();
        }

        gameObject.transform.Translate(direction.normalized * distanceToTravel, Space.World);
    }

    private void HitTarget()
    {
        if (ImpactEffectPrefab != null)
        {
            // Create the impact effect and then destroy it after 2s
            var effectInstance = Instantiate(ImpactEffectPrefab, gameObject.transform.position,  gameObject.transform.rotation);

            Destroy(effectInstance, 2f);
        }

        Destroy(gameObject);

        // TODO : Assign damage to target, but for now we just destroy the target
        _targetEnemy.TakeDamage(Damage);
    }
}
