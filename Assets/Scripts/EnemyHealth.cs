using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    private float _health = 2;

    public void DamageEnemy()
    {
        _health -= GlobalState.ProjectileDamage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
