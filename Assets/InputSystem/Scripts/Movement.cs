
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float forwardSpeed = 1f;
    public float leftSpeed = 1.5f;
    public float rightSpeed = 1.5f;
    public float backwardSpeed = 1f;
    private Rigidbody rb;
    private bool isMovingForward;
    private bool isMoviingLeft;
    private bool isMovingRight;
    private bool IsMovingBackward;
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
            isMoviingLeft = true;
        }
        else if (context.canceled)
        {
            isMoviingLeft = false;
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
            IsMovingBackward = true;
        }
        else if (context.canceled)
        {
            IsMovingBackward = false;
        }
    }



    public void isMoving()
    {
         if (isMovingForward)
        {
            rb.AddForce(transform.forward * forwardSpeed, ForceMode.Impulse); 
        }
        if (isMoviingLeft)
        {
            rb.AddForce(-transform.right * leftSpeed, ForceMode.Impulse); 
        }
        if (isMovingRight)
        {
            rb.AddForce(transform.right * rightSpeed, ForceMode.Impulse);
        }
        if (IsMovingBackward)
        {
            rb.AddForce(-transform.forward * backwardSpeed, ForceMode.Impulse);
        }
    }



    #endregion
    //global/world directions (Vector3.forward, Vector3.right)
    // thats why here is transform insted of Vector3.
    // left = negative right
    void FixedUpdate()
    {
        isMoving();
    }





}