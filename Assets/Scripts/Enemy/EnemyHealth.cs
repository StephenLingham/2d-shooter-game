using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    public float Health = 2;

    public void DamageEnemy()
    {
        Health -= GlobalState.ProjectileDamage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
