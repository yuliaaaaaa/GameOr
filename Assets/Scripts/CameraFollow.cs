using UnityEngine;

public class CameraFollow : MonoBehaviour
{/*
    public Transform target; // ГГ, за яким буде слідкувати камера
    public float smoothSpeed = 0.125f; // Плавність руху камери
    public Vector3 offset; // Відстань між камерою і цільовим об'єктом
    public Vector3 rotationOffset; // Значення для орієнтації (rotation) камери

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Змінюємо орієнтацію камери
        transform.rotation = Quaternion.Euler(rotationOffset);

        // Направляємо камеру на ГГ
        transform.LookAt(target);
    }
*/
  
    public Transform player; // Гравець, до якого прикріплена камера
    public float cameraDistance = 5f; // Відстань від камери до гравця
    public float cameraHeight = 2f; // Висота камери над гравцем
    public float rotationSpeed = 10f; // Швидкість обертання камери

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Отримуємо положення миші у світових координатах
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y));
        
        // Визначаємо вектор, що вказує на мишу відносно положення гравця
        Vector3 direction = (mousePosition - player.position).normalized;

        // Визначаємо положення камери ззаду та зверху гравця
        Vector3 cameraPosition = player.position - direction * cameraDistance + Vector3.up * cameraHeight;
        
        // Повертаємо камеру в напрямку миші з плавним обертанням
        Quaternion lookRotation = Quaternion.LookRotation(player.position - cameraPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Зміщуємо камеру до визначеної позиції
        transform.position = cameraPosition;
    }
}