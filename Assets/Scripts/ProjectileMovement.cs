using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Vector3 ProfectileDirection { get; set; } = Vector3.zero;

    void Update()
    {
        Vector3 movement = GlobalState.ProjectileSpeed * Time.deltaTime * ProfectileDirection;

        transform.position += movement;
    }
}
