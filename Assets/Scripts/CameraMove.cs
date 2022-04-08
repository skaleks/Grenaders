using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float sensitivity = 100f;
    private float xRotation;
    [SerializeField]
    private Transform body;


    private void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
