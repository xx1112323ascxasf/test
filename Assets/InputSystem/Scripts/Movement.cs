
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

    [Header("Movement")]
    #region Movement
    public float moveForce = 10f;

    private Vector2 moveInput;


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 forceDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        rb.AddForce(forceDirection * moveForce, ForceMode.Force);
    }
    #endregion
    
    
    [Header("Ground Check")]
    #region GroundCheck

    
    #endregion
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        MovePlayer();
    }
}