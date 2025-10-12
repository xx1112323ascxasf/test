using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    #region test 
    //add to inspector 
    public InputActionReference fire;





    public void Dash(InputAction.CallbackContext context)
    {
        // B KEY 
        Debug.Log("SussyBaka");
    }

    #endregion


    private Vector2 moveInput;
    public float moveSpeed = 10.0f;
    public Rigidbody frb;
    public Vector3 fmovement;


    public void Start()
    {
        frb = GetComponent<Rigidbody>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        Debug.Log("Move");
    }

    public void FixedUpdate()
    {
        

        frb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    
    }
}  
