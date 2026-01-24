using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class JumpController : MonoBehaviour
{

    public bool isGrounded() //invoke GroundCheck script
    {
        GroundCheck groundCheck = GetComponent<GroundCheck>();
        return groundCheck.IsGrounded();
    }

    public bool isLowGrounded() //invoke LowGroundCheck script
    {
        LowGroundCheck lowGroundCheck = GetComponent<LowGroundCheck>();
        return lowGroundCheck.IsLowGrounded();
    }





    public void Jump(InputAction.CallbackContext context )
    {
    

        if (context.phase == InputActionPhase.Performed && isGrounded()) //&& GroundCHECK()
        {
            Debug.Log("jump!");

            rb.AddForce(transform.up * m_Thrust);
        }
        

    

        else if (context.phase == InputActionPhase.Performed && isLowGrounded()) 
        {
            Debug.Log("low jump!");

            rb.AddForce(transform.up * m_Thrust);
            rb.AddForce(transform.forward * f_Thrust);
        }
    }





    Rigidbody rb;
    public float m_Thrust = 20f;
    public float f_Thrust = 40f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   




    
    
    
    #region  test

    #endregion

}
