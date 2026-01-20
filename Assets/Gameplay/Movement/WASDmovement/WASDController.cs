
using UnityEngine;
using UnityEngine.InputSystem; 


public class Movement : MonoBehaviour
{

    GroundCheck groundCheck;





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

        rb.AddForce(forceDirection * moveForce * 10f, ForceMode.Impulse);
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