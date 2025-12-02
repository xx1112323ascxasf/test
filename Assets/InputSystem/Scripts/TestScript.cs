using UnityEngine;

public class TestScript : MonoBehaviour
{
    
    public float maxSpeed = 10f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void test()
    {
                
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
          
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void FixedUpdate()
    {
        //test();
    }
}
