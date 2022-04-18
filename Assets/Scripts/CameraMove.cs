using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;
    private float _sensitivity = 100f;
    private float _xRotation;
    [SerializeField]
    private Transform _body;


    private void Update()
    {
        _mouseX = Input.GetAxisRaw("Mouse X") * _sensitivity * Time.deltaTime;
        _mouseY = Input.GetAxisRaw("Mouse Y") * _sensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _body.Rotate(Vector3.up * _mouseX);
    }
}
