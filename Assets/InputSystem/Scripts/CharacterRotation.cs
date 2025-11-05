using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
 
    public Rigidbody rb;
    public Transform cameraTransform; 

    public float rotationSpeed = 40f;

    void Start()
    {
        Cursor.visible = false;                
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void FixedUpdate()
    {
        if (cameraTransform == null || rb == null) return;

        Vector3 targetDirection = cameraTransform.forward;
        targetDirection.y = 0f;

        if (targetDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            Quaternion smoothedRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(smoothedRotation);
        }
    }

}
