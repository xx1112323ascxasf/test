
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

    [Header("Movement")]
    #region Movement
    public float moveSpeed;

    public float groundDrag;

    private Rigidbody rb;

    private Vector2 moveInput;


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);

        Vector3 forceDirection = transform.TransformDirection(inputDir);

        rb.AddForce(forceDirection * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x,0f,rb.linearVelocity.z);
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z); //limitedspeed apply
        }
    }
    #endregion
    
    
    [Header("Ground Check")]
    #region GroundCheck

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    private void GroundCheck()
    {

        //later change to spherecast
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f,whatIsGround);

        if (grounded)
            rb.linearDamping = groundDrag;

        else
            rb.linearDamping = 0;
    }



    #endregion




    #region startupdate
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    { 
        SpeedControl();
        GroundCheck();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    #endregion





    #region jump
    #endregion
}