using UnityEngine;
using UnityEngine.InputSystem;
public class CarController : MonoBehaviour
{
    public WheelController[] wheels; // Array to hold references to the wheel controllers


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

        foreach (WheelController w in wheels) // Loop through each wheel controller
        {
            if (w.wheelFrontLeft)
            {
                w.steerAngle = ackermannAngleLeft;
            }
            if (w.wheelFrontRight)
            {
                w.steerAngle = ackermannAngleRight;
            }
        }

    }

}
