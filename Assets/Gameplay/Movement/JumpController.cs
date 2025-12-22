using UnityEngine;
using UnityEngine.InputSystem;
public class JumpController : MonoBehaviour
{
    public void Jump(InputAction.CallbackContext context)
    {
    

        if (context.phase == InputActionPhase.Performed)
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

    void FixedUpdate()
    {

    }

}
