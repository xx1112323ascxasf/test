using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    private void Sart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
    public Transform orientation;
    public Transform player;
    public Transform PlayerObject;
    public Rigidbody rb;

    public float rotationSpeed;

    public void Update()
    {
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxisRaw("Horizonta;");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
            PlayerObject.forward = Vector3.Slerp(PlayerObject.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);

    }
}
