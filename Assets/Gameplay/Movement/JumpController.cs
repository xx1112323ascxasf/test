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
    public void Jump(InputAction.CallbackContext context )
    {
    

        if (context.phase == InputActionPhase.Performed && isGrounded()) //&& GroundCHECK()
        {
            Debug.Log("jump!");

            rb.AddForce(transform.up * m_Thrust);
        }

    }





    Rigidbody rb;
    public float m_Thrust = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   




    
    
    
    #region  test
    // void OnDrawGizmos()
    // {
    //     Gizmos.color =Color.red;
    //     Gizmos.DrawWireCube(transform.position - transform.up * maxDistance, boxSize);
    // }

    // [SerializeField] private bool isGrounded; 
    // public bool IsGrounded => isGrounded;
    // public bool GroundCHECK()
    // {
    //     if(Physics.BoxCast(transform.position,boxSize,-transform.up,transform.rotation,maxDistance,layerMask)) //1 center, 2 size, 3 diraction 
    //     {
    //         return true;


    //     }   

    //     else
    //     {
    //         return false;
    //     }      
         
    // }

    #endregion

}
