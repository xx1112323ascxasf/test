using UnityEngine;
using UnityEngine.InputSystem;
public class JumpController : MonoBehaviour
{
    public void Jump(InputAction.CallbackContext context )
    {
    

        if (context.phase == InputActionPhase.Performed && GroundCHECK())
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
   


    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;


    void Update()
    {
   
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * maxDistance, boxSize);
    }

    public bool GroundCHECK()
    {
        if(Physics.BoxCast(transform.position,boxSize,-transform.up,transform.rotation,maxDistance,layerMask)) //1 center, 2 size, 3 diraction 
        {
            return true;
            

        }   

        else
        {
            return false;
        }      
         
    }

}
