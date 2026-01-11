using UnityEngine;
public class SpeedLimitController : MonoBehaviour
{
    private Rigidbody rb;   
    public float maxSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
