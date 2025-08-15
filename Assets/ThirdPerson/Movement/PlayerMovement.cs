using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verctialInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();
    }
    void FixedUpdate()
    {
        MovePlayer();   
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizonta;");
        verctialInput = Input.GetAxisRaw("Verctial");

    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verctialInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

}
