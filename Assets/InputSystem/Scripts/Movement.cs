
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;
    private bool isMovingForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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

    void FixedUpdate()
    {
        if (isMovingForward)
        {
            rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);
        }
    }
}