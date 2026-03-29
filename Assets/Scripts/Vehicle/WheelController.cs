using UnityEngine;

public class WheelController : MonoBehaviour
{
    private Rigidbody rb;

    public bool wheelFrontLeft;
    public bool wheelFrontRight;
    public bool wheelRearLeft;  
    public bool wheelRearRight; 

    [Header("Suspension")]
    public float restLength;
    public float springTravel;
    public float springStiffness;
    public float damperStiffness;



    private float minLength;
    private float maxLength;
    private float lastLength;

    private float springLength;
    private float springForce;
    private float springVelocity;
    private float damperForce;
   

    private Vector3 suspensionForce;

    [Header ("Wheel")]
    public float wheelRadius;

    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody>();

        minLength = restLength - springLength;
        maxLength = restLength + springTravel;

 
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + wheelRadius))

        {
            lastLength = springLength;

            springLength = hit.distance - wheelRadius; 
            springLength = Mathf.Clamp(springLength, minLength, maxLength); 
            springVelocity = (lastLength - springLength) / Time.fixedDeltaTime; //distance change over time 
 
            springForce = springStiffness * (restLength - springLength);

            suspensionForce = (springForce + damperForce) * transform.up;

            damperForce = damperStiffness * springVelocity;

            rb.AddForceAtPosition(suspensionForce, hit.point);
        }
    }
}
