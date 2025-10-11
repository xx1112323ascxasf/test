using UnityEngine;

public class rbFirstPerson : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody fpRigitBody;

    private void Start()
    {
        fpRigitBody = GetComponent<Rigidbody>();

        fpRigitBody.freezeRotation = true;

        

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        MyInput();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        fpRigitBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
