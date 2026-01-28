using Unity.VisualScripting;
using UnityEngine;

public class StopWhileGrounded : MonoBehaviour
{
    Rigidbody rb;
    GroundCheck groundCheck;

    [Tooltip("Smooth time for horizontal velocity to reach zero. Smaller = snappier.")]
    public float smoothTime = 0.08f;

    [Tooltip("If > 0, uses MoveTowards with this deceleration (units/sec^2) instead of SmoothDamp.")]
    public float deceleration = 0f;

    // internal ref used by SmoothDamp
    private Vector3 horizontalVelocityRef = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();


    }

    void FixedUpdate()
    {
        if (rb == null || groundCheck == null) return;

        if (groundCheck.IsGrounded())
        {
            Vector3 current = rb.linearVelocity;
            Vector3 currentHorizontal = new Vector3(current.x, 0f, current.z);

            Vector3 newHorizontal;
            if (deceleration > 0f)
            {

                newHorizontal = Vector3.MoveTowards(currentHorizontal, Vector3.zero, deceleration * Time.fixedDeltaTime);
   
                horizontalVelocityRef = Vector3.zero;
            }
            else
            {

                newHorizontal = Vector3.SmoothDamp(currentHorizontal, Vector3.zero, ref horizontalVelocityRef, smoothTime, Mathf.Infinity, Time.fixedDeltaTime);
            }

            rb.linearVelocity = new Vector3(newHorizontal.x, current.y, newHorizontal.z);
        }
    }
}