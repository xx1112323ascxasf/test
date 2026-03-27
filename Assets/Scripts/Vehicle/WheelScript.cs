using UnityEngine;

public class VehicleScript : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Suspension")]
    public float restLength;
    public float sprntTravel;

    private float minLength;
    private float maxLength;
    private float sprintLength;

    [Header ("Wheel")]
    public float wheelRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        minLength = restLength - sprintLength;
        maxLength = restLength + sprntTravel;

 
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + wheelRadius))
        {
            sprintLength = hit.distance - wheelRadius; 
        }
    }
}
