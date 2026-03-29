using UnityEngine;
using UnityEngine.InputSystem;
public class CarController : MonoBehaviour
{
    public WheelCollider wheels;

    [Header("Car Specs")]
    public float wheelBase;
    public float rearTrack;
    public float turnRadius;

    [Header("Input")]
    public float steerInput;


    public float ackermannAngleLeft;
    public float ackermannAngleRight;  

    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");

        if (steerInput > 0)
        {
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + rearTrack / 2)) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - rearTrack / 2)) * steerInput;

            
        }
        else if (steerInput < 0)
        {
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - rearTrack / 2)) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + rearTrack / 2)) * steerInput;

         
        }
        else
        {
            ackermannAngleLeft  = 0;
            ackermannAngleRight = 0;
        }


    }

}
