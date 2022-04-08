using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;
    private float speed = 10f;
    private float horizontalInput;
    private float verticalInput;
    private float gravity = 100f;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;

        if (!player.isGrounded)
        {
            movement.y = -gravity * Time.deltaTime;
        }

        player.Move(movement * speed * Time.deltaTime);
    }
}
