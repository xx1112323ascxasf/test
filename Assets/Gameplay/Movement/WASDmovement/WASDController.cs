
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

    public bool isGrounded() //invoke GroundCheck script
    {
        GroundCheck groundCheck = GetComponent<GroundCheck>();
        return groundCheck.IsGrounded();
    }

    // make special grounded for movement, like "IS LOWGROUNDED" even can use raycast as base



    [Header("Movement")]
    #region Movement
    public float moveForce = 20f;
     
    
    

    private Rigidbody rb;

    private Vector2 moveInput;

  
       
        public void OnMove(InputAction.CallbackContext context )
        {
            moveInput = context.ReadValue<Vector2>();
        }


        private void MovePlayer() //local variables
        {
             Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);

            Vector3 forceDirection = transform.TransformDirection(inputDir); 



            if(isGrounded())
            {
                rb.AddForce(forceDirection * moveForce * 10f, ForceMode.Impulse);
            }
            else
            {
               rb.AddForce(forceDirection * moveForce * 20f, ForceMode.Acceleration);
            }
            

        }


    


    #region startupdate
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


        private void Update()
    { 
    
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    #endregion




    
    



    #endregion






}