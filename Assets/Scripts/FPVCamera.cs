using UnityEngine;

public class FPV_Camera : MonoBehaviour
{
    // Чувствительность мыши (можно настроить в инспекторе Unity)
    [SerializeField] private float mouseSensitivity = 100f;

    // Ссылка на тело игрока, чтобы вращать его вместе с камерой
    [SerializeField] private Transform playerBody;

    // Переменная для отслеживания вращения по оси X (вверх-вниз)
    private float xRotation = 0f;

    void Start()
    {
        // Блокируем курсор в центре экрана и скрываем его
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Обновляем вращение камеры вверх-вниз
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничиваем угол обзора (чтобы не переворачиваться)

        // Применяем вращение камеры
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Вращаем тело игрока влево-вправо
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
