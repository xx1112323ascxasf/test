
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
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



    #endregion

    void FixedUpdate()
    {
        if (isMovingForward)
        {
            rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
        }
        if (isMoviingLeft)
        {
            rb.AddForce(Vector3.left * moveSpeed, ForceMode.Impulse);
        }

        if (isMovingRight)
        {
            rb.AddForce(Vector3.right, ForceMode.Impulse);
        }

        if (IsMovingBackward)
        {
            rb.AddForce(Vector3.back, ForceMode.Impulse);
        }



    }
}