using UnityEngine;
using Unity.Cinemachine;

public class FPCamera : CinemachineExtension


{

    public Transform orientation;
    public Transform player;
    public Transform PlayerObj;
    public Rigidbody fpRigitBody;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        // orientation rotate
        
        Vector3 viewDir = new Vector3(transform.position.x, player.position.y, transform.position.z);
        
        orientation.forward = viewDir.normalized;

        // rotate player object

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            PlayerObj.forward = Vector3.Slerp(PlayerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
    

}