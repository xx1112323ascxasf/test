using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    #region Test
    public InputActionReference fire;

    public void Dash(InputAction.CallbackContext context)
    {
        // B KEY 
        Debug.Log("SussyBaka");
    }
    #endregion

    private Vector2 moveInput;
    public float moveSpeed = 10.0f;
    private Rigidbody frb;

    private void Start()
    {
        frb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);

        frb.AddForce(movement * moveSpeed, ForceMode.Force);

        if (movement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            frb.MoveRotation(Quaternion.Slerp(frb.rotation, targetRotation, Time.fixedDeltaTime * 10f));
        }
    }
}