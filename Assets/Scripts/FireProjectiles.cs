using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    private float fireTimer = 0f;
    private Transform nearestEnemy;

    public Transform projectilePrefab;

    public void Update()
    {
        fireTimer += Time.deltaTime;

        FindNearestEnemy();

        if (nearestEnemy == null)
        {
            return;
        }

        if (fireTimer >= GlobalState.RateOfFire)
        {
            FireProjectile();

            fireTimer = 0f;
        }
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < nearestDistance)
            {
                nearestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }
    }

    private void FireProjectile()
    {
        if (nearestEnemy == null)
        {
            return;
        }

        Transform projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector3 directionToEnemy = (nearestEnemy.position - transform.position).normalized;

        projectile.GetComponent<ProjectileMovement>().ProfectileDirection = directionToEnemy;
    }
}
