using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementNoJump : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float gravity = 9.81f;

    public Camera mainCamera;

    public float facing = Camera.main.transform.eulerAngles.y;
    

    // hype

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    { 
        //cameraconnecton
        float cameraFacing = mainCamera.transform.eulerAngles.y;


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 turnedInputVector = Quaternion.Euler(0, cameraFacing, 0) * inputVector;
        //inputDirection.transform.LookAt(turnedInputVector);
        



       

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.Normalize(); 

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -1f; 
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}