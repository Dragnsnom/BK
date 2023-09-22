using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения камеры
    public float rotationSpeed = 2f; // Скорость вращения камеры
    public float zoomSpeed = 0.5f; // Скорость приближения/отдаления камеры
    private float zoomDistance = 0f; // Текущее приближение

    void Update()
    {
        // Перемещение камеры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        if (Input.GetMouseButton(1))
        {
            // Вращение камеры с помощью мыши
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(transform.position, Vector3.up, mouseX);
            transform.RotateAround(transform.position, transform.right, -mouseY);
        }

        // Приближение/отдаление с помощью колеса мыши
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0)
        {
            zoomDistance = 0f;
            zoomDistance += scrollWheelInput * zoomSpeed;
            zoomDistance = Mathf.Clamp(zoomDistance, -1, 1); // Ограничить минимальное и максимальное приближение
            Vector3 zoomPosition = transform.position + transform.forward * zoomDistance;
            transform.position = zoomPosition;
        }
    }
}
