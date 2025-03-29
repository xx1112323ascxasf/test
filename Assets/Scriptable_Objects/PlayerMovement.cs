using UnityEngine;
using Marchenkostuff;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementInputData movementInputData;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float crouchSpeed = 1.5f;
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 velocity;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float speed = movementInputData.IsRunning ? runSpeed :
                      movementInputData.IsCrouching ? crouchSpeed : walkSpeed;

        Vector3 move = transform.right * movementInputData.InputVector.x +
                       transform.forward * movementInputData.InputVector.y;

        characterController.Move(move * speed * Time.deltaTime);

        if (movementInputData.JumpClicked && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
