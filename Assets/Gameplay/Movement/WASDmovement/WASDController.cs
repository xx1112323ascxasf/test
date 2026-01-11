
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

    [Header("Movement")]
    #region Movement
    public float moveForce;

    

    private Rigidbody rb;

    private Vector2 moveInput;


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer() //local variables
    {
        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);

        Vector3 forceDirection = transform.TransformDirection(inputDir); 

        rb.AddForce(forceDirection * moveForce * 10f, ForceMode.Impulse);
    }


    


    #region startupdate
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    { 
        //SpeedControl(); //while press w and a/d may be a reason for jitter 
        //GroundCheck();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    #endregion




    #region test


    #endregion
    
    



    #endregion






}