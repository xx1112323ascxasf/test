using UnityEngine;
using Marchenkostuff;

public class PlayerMovement : MonoBehaviour
{
    // Ссылка на данные ввода движения
    [SerializeField] private MovementInputData movementInputData;

    // Компонент CharacterController для управления перемещением
    [SerializeField] private CharacterController characterController;

    // Скорость передвижения (ходьба, бег, приседание)
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float crouchSpeed = 1.5f;

    // Параметры прыжка
    [SerializeField] private float jumpHeight = 1.2f; // Высота прыжка
    [SerializeField] private float gravity = -9.81f;  // Гравитация

    // Койот-тайм: время, в течение которого можно прыгнуть после схода с платформы
    [SerializeField] private float coyoteTime = 0.2f;

    // Буфер прыжка: если игрок нажал прыжок чуть раньше приземления, он всё равно сработает
    [SerializeField] private float jumpBufferTime = 0.2f;

    private Vector3 velocity;   // Вектор скорости персонажа
    private bool isGrounded;    // Флаг, находится ли персонаж на земле
    private float coyoteTimeCounter;  // Счётчик койот-тайма
    private float jumpBufferCounter;  // Счётчик буфера прыжка

    private void Update()
    {
        // Проверяем, касается ли персонаж земли
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            // Если на земле, сбрасываем койот-тайм
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            // Если в воздухе, уменьшаем таймер койот-тайма
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Буфер прыжка: сохраняем факт нажатия кнопки прыжка
        if (movementInputData.JumpClicked)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        MovePlayer(); // Вызываем метод передвижения игрока
    }

    private void MovePlayer()
    {
        // Определяем текущую скорость в зависимости от состояния игрока (ходьба, бег, приседание)
        float speed = movementInputData.IsRunning ? runSpeed :
                      movementInputData.IsCrouching ? crouchSpeed : walkSpeed;

        // Рассчитываем движение на основе входных данных
        Vector3 move = transform.right * movementInputData.InputVector.x +
                       transform.forward * movementInputData.InputVector.y;

        // Перемещаем персонажа
        characterController.Move(move * speed * Time.deltaTime);

        // Обработка прыжка с учетом койот-тайма и буфера прыжка
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Рассчитываем силу прыжка
            coyoteTimeCounter = 0f;  // Обнуляем койот-тайм
            jumpBufferCounter = 0f;  // Обнуляем буфер прыжка
        }

        // Применяем гравитацию (ускоряем падение, если игрок не удерживает прыжок)
        if (!isGrounded)
        {
            float gravityMultiplier = (velocity.y < 0) ? 2f : 1f; // Ускоряем падение вниз
            velocity.y += gravity * gravityMultiplier * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f; // Небольшая сила вниз, чтобы персонаж не "парил" над землёй
        }

        // Применяем гравитацию к персонажу
        characterController.Move(velocity * Time.deltaTime);
    }
}
