using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = GlobalState.PlayerSpeed * Time.deltaTime * new Vector3(moveHorizontal, moveVertical, 0f).normalized;

        transform.position += movement;
    }
}
