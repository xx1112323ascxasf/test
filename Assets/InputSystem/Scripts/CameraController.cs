using UnityEngine;



public class PlayerLook : MonoBehaviour
{
    #region characterortation
    
    
    public Transform cameraObject;   
    public float rotationSpeed = 10f;   

   

    void RotateToCameraDirection()
    {
       
        Vector3 cameraForward = cameraObject.forward;
        cameraForward.y = 0f;                       
        if (cameraForward.sqrMagnitude < 0.01f) return;

       
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
  
    }
    void FixedUpdate()
    {
        RotateToCameraDirection();
    }
}
