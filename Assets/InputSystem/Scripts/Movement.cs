
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

    
 
    public float forwardSpeed = 1f;
    public float leftSpeed = 1.5f;
    public float rightSpeed = 1.5f;
    public float backwardSpeed = 1f;

    private Rigidbody rb;
    private bool isMovingForward;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isMovingBackward;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    #region input actions


    public void MoveForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMovingForward = true;
        }
        else if (context.canceled)
        {
            isMovingForward = false;
        }
    }
    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMovingLeft = true;
        }
        else if (context.canceled)
        {
            isMovingLeft = false;
        }
    }
    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMovingRight = true;
        }
        else if (context.canceled)
        {
            isMovingRight = false;
        }
    }
    public void MoveBackward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMovingBackward = true;
        }
        else if (context.canceled)
        {
            isMovingBackward = false;
        }
    }



    public void isMoving()
    {
         if (isMovingForward)
        {
            rb.AddForce(transform.forward * forwardSpeed , ForceMode.Impulse); 
        }
        if (isMovingLeft)
        {
            rb.AddForce(-transform.right * leftSpeed , ForceMode.Impulse); 
        }
        if (isMovingRight)
        {
            rb.AddForce(transform.right * rightSpeed , ForceMode.Impulse);
        }
        if (isMovingBackward)
        {
            rb.AddForce(-transform.forward * backwardSpeed , ForceMode.Impulse);
        }
    }





    #endregion
    //global/world directions (Vector3.forward, Vector3.right)
    // thats why here is transform insted of Vector3.
    // left = negative right

    #region speedcontrol

    [Header("Movement")]

    public float JumpForce;
    public float JumpCooldown;
    public float airMultiplayer;

    bool readyToJump; 



    public float groundDrag;

    [Header("Ground Check")]

    public float playerHeight;

    public LayerMask whatIsGround;

   

    bool grounded;
    public void GroundCheck()  //later make spherecast
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if(grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
       
    }

    
    public void Jump(InputAction.CallbackContext context)
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);


    }

    public void ResetJump()
    {
        readyToJump = true;  
    }

    
 
    

  
    #endregion
    void FixedUpdate()
    {
        isMoving();
        
    }

    void Update()
    {
        GroundCheck();
    }





}