using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


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
        GroundCheck();
        SpeedControl();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verctialInput = Input.GetAxisRaw("Vertical");

    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verctialInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    private void GroundCheck()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);

        }

    }

}
