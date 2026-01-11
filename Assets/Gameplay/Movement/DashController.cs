using UnityEngine;
using UnityEngine.InputSystem;


public class DashController : MonoBehaviour
{
    [Header("Dash Settings")]


    public float m_Thrust = 20f; 
    private Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }

    public void OnDash(InputAction.CallbackContext context)
    {   
            if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("dash!");

            rb.AddForce(transform.forward * m_Thrust);
        }
    }   
}