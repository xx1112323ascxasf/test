using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{


    public Transform orientation;
    public Transform player;
    public Transform PlayerObject;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public CameraStyle currentStyle;

    public enum CameraStyle
    {
        Basic,
        Combat
    }
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Update()
    {
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        if (currentStyle == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDirection != Vector3.zero)
                PlayerObject.forward = Vector3.Slerp(PlayerObject.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
        }
        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 directoryToCombat = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = directoryToCombat.normalized;

            PlayerObject.forward = directoryToCombat.normalized;
        }

    }
}
