using UnityEngine;



public class PlayerLook : MonoBehaviour
{
    #region characterortation
    
    
    public Transform cameraObject;
    public float rotationSpeed = 10f;
    public Rigidbody rb;

    private Vector3 _desiredForward; 

   
    void CameraDirection()
    {
        Vector3 camForward = cameraObject.forward;
        camForward.y = 0f;
        if (camForward.sqrMagnitude > 0.0001f)
        _desiredForward = camForward.normalized;
    }

    void RotateToCameraDirection()
    {
       
        if (_desiredForward.sqrMagnitude < 0.0001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(_desiredForward);

        Quaternion newRotation = Quaternion.Slerp
        (
        rb.rotation,
        targetRotation,
        rotationSpeed * Time.fixedDeltaTime
        );

        rb.MoveRotation(newRotation);
    }




    #endregion
    #region cursor lock

    void CursorLock()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        
        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
    }

        void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;                    
    }

    #endregion


    void Start()
    {
        LockCursor();
    }


    void Update()
    {
        CursorLock();
        CameraDirection();
  
    }
    void FixedUpdate()
    {
        RotateToCameraDirection();
    }
}
