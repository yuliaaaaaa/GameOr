using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Чутливість миші
    public float minYAngle = -80f; // Мінімальний кут обертання камери
    public float maxYAngle = 80f; // Максимальний кут обертання камери
    public float minXAngle = -80f; // Мінімальний кут обертання камери
    public float maxXAngle = 80f; // Максимальний кут обертання камери

    private float rotationX = 0f;
    private float rotationY = 0f;
    private float smoothRotationX = 0f;
    private float smoothRotationY = 0f;
    public float smoothTime = 0.1f; // Час згладжування

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Закріплюємо курсор у центрі екрану
    }

    void Update()
    {
        // Отримуємо зміщення миші за віссю X та Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Рахуємо обертання камери згладженим шляхом
        smoothRotationX = Mathf.Lerp(smoothRotationX, mouseX, smoothTime);
        smoothRotationY = Mathf.Lerp(smoothRotationY, mouseY, smoothTime);

        // Додаємо обертання
        rotationX -= smoothRotationY;
        rotationY += smoothRotationX;

        // Обмежуємо обертання по вертикалі
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);
        rotationY = Mathf.Clamp(rotationY, minXAngle, maxXAngle);

        // Застосовуємо обертання камери
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}