using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху персонажа
    public float rotationSpeed = 10f; // Швидкість обертання персонажа

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Отримуємо положення миші у світових координатах
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y));
        
        // Визначаємо вектор, що вказує на мишу відносно положення персонажа
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Повертаємо персонажа в напрямку миші з плавним обертанням
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f), Time.deltaTime * rotationSpeed);

        // Змінюємо положення персонажа на основі визначеного вектора напрямку
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }
}