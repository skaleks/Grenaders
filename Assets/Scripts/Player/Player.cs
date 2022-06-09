using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string BombTag = "Bomb";
    private const string EnemyTag = "Enemy";

    private float _horizontalInput;
    private float _verticalInput;
    private bool _canMove = true;
    private float _speed = 10f;
    private float _gravity = 100f;
    private Vector3 direction;

    [SerializeField]
    private float power;
    [SerializeField]
    protected CharacterController _player;
    [SerializeField]
    private BombTrajectoryRenderer _trajectoryRenderer;
    [SerializeField]
    private GameContentGenerator _contentGenerator;
    [SerializeField]
    private Gunsight _gunsight;


    public Action<Vector3> OnBombThrown;

    private void Update()
    {
        if (_canMove) Move();

        if (Input.GetMouseButton(0))
        {
            PrepareThrow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ThrowBomb();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BombTag))
        {
            _contentGenerator.OnBombTriggered(other.gameObject);
        }
    }
    public void Move()
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
    private void ThrowBomb()
    {
        GameObject bomb = _contentGenerator.GetBomb(_trajectoryRenderer.transform.position);

        bomb.GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);


        _canMove = true;
        _gunsight.OFF();
        _trajectoryRenderer.ClearLine();
    }

    private void PrepareThrow()
    {
        _canMove = false;
        _gunsight.ON();


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag(EnemyTag))
        {
            direction = hit.point - transform.position;

            _trajectoryRenderer.Render(direction);
        }
        else
        {
            _trajectoryRenderer.ClearLine();
        }
    }
}
