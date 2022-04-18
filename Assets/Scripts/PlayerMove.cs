using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private CharacterController _player;
    private float _speed = 10f;
    private float _horizontalInput;
    private float _verticalInput;
    private float _gravity = 100f;

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = transform.right * _horizontalInput + transform.forward * _verticalInput;

        if (!_player.isGrounded)
        {
            movement.y = -_gravity * Time.deltaTime;
        }

        _player.Move(movement * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       // To do
    }
}
