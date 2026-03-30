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
    public InputAction steerAction;

    public float ackermannAngleLeft;
    public float ackermannAngleRight;

    public void OnEnable()
    {
        if (steerAction != null)
        {
            steerAction.Enable();
            steerAction.performed += OnSteer;
            steerAction.canceled += OnSteer;
        }
    }

    public void OnDisable()
    {
        if (steerAction != null)
        {
            steerAction.performed -= OnSteer;
            steerAction.canceled -= OnSteer;
            steerAction.Disable();
        }
    }

    public void OnSteer(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        steerInput = context.ReadValue<float>();

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
            ackermannAngleLeft = 0;
            ackermannAngleRight = 0;
        }
    }
}