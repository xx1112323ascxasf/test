
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

  public float moveForce = 10f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        
    }
}