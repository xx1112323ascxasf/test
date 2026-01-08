using UnityEngine;
using UnityEngine.InputSystem;


public class DashController : MonoBehaviour
{
    [Header("Dash Settings")]
    public float dashForce = 20f;
    public float dashCooldown = 1f;

    private Rigidbody rb;
    private float lastDashTime;

    private Vector3 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveDirection = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (Time.time < lastDashTime + dashCooldown) return;

        Vector3 dashDir;

        if (moveDirection.magnitude > 0.1f)
            dashDir = moveDirection.normalized;
        else
            dashDir = transform.forward; // если стоим на месте

        rb.AddForce(dashDir * dashForce, ForceMode.Impulse);

        lastDashTime = Time.time;
    }
}