using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private float _health;
    private Collider2D _collider;
    private readonly List<GameObject> _enemiesAlreadyHit = new();

    void Start()
    {
        _health = GlobalState.ProjectilePiercing;
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            if (_enemiesAlreadyHit.Contains(enemy))
            {
                continue;
            }

            var enemyCollider = enemy.GetComponent<Collider2D>();

            if (_collider.bounds.Intersects(enemyCollider.bounds))
            {
                HitEnemy(enemy);
            }
        }
    }

    private void HitEnemy(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealth>().DamageEnemy();
        _enemiesAlreadyHit.Add(enemy);

        _health--;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
