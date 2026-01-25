using UnityEngine;

public class StopWhileGrounded : MonoBehaviour
{
    public bool isGrounded() //invoke GroundCheck script
    {
        GroundCheck groundCheck = GetComponent<GroundCheck>();
        return groundCheck.IsGrounded();
    }
    void Update()
    {
        if (isGrounded())
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
        }
    }

}
