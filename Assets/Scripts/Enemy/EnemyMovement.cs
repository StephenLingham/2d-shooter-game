using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    public float MovementSpeed = 4f;

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError($"{nameof(EnemyMovement)} - Could not find game object named 'Player'");
        }
    }

    private void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Vector3 movement = MovementSpeed * Time.deltaTime * direction;
        transform.position += movement;
    }
}
