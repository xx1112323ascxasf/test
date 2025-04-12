using NaughtyAttributes;
using UnityEngine;

namespace VHSMarchenko
{    
    public class CameraController : MonoBehaviour
    {
        #region Variables
            #region Data
                [Space,Header("Data")]
                [SerializeField] private CameraInputData camInputData = null;

                [Space,Header("Custom Classes")]
                [SerializeField] private CameraZoom cameraZoom = null;
                [SerializeField] private CameraSwaying cameraSway = null;

            #endregion

            #region Settings
                [Space,Header("Look Settings")]
                [SerializeField] private Vector2 sensitivity = Vector2.zero;
                [SerializeField] private Vector2 smoothAmount = Vector2.zero;  // Smoothing factors for rotation 
                [SerializeField] [MinMaxSlider(-90f,90f)] private Vector2 lookAngleMinMax = Vector2.zero;  // Clamps vertical look angles between -90 and 90 degrees (using NaughtyAttributes slider)

            #endregion

            #region Private
               private float m_yaw; // Current horizontal rotation 
               private float m_pitch; // Current vertical rotation  

               private float m_desiredYaw;  // Target horizontal rotation 
               private float m_desiredPitch; // Target vertical rotation 

                #region Components                    
                    private Transform m_pitchTranform;
                    private Camera m_cam; // The actual camera component 
                #endregion
            #endregion
            
        #endregion

        #region BuiltIn Methods  
            void Awake()
            {
                GetComponents();  // Get required components 
                InitValues(); // Initialize starting values 
                InitComponents(); // Initialize custom components 
                ChangeCursorState(); // Lock and hide cursor 
            }

            void LateUpdate()  // Runs after all Update() calls complete 
            {
                CalculateRotation();
                SmoothRotation();
                ApplyRotation();
                HandleZoom();
            }
        #endregion

        #region Custom Methods
            void GetComponents()
            {
                m_pitchTranform = transform.GetChild(0).transform; // Gets the first child transform (used for vertical rotation) 
                m_cam = GetComponentInChildren<Camera>();  // Gets the camera component in children 
            }

            void InitValues()
            {
                m_yaw = transform.eulerAngles.y;
                m_desiredYaw = m_yaw;
            }

            void InitComponents()  // Initialize custom components вызываем темку 
            {
                cameraZoom.Init(m_cam, camInputData);
                cameraSway.Init(m_cam.transform);
            }

            void CalculateRotation()
            {
                m_desiredYaw += camInputData.InputVector.x * sensitivity.x * Time.deltaTime;
                m_desiredPitch -= camInputData.InputVector.y * sensitivity.y * Time.deltaTime;

                m_desiredPitch = Mathf.Clamp(m_desiredPitch,lookAngleMinMax.x,lookAngleMinMax.y);
            }

            void SmoothRotation()
            {
                m_yaw = Mathf.Lerp(m_yaw,m_desiredYaw, smoothAmount.x * Time.deltaTime);
                m_pitch = Mathf.Lerp(m_pitch,m_desiredPitch, smoothAmount.y * Time.deltaTime);
            }

            void ApplyRotation()
            {
                transform.eulerAngles = new Vector3(0f,m_yaw,0f);
                m_pitchTranform.localEulerAngles = new Vector3(m_pitch,0f,0f);
            }

            public void HandleSway(Vector3 _inputVector,float _rawXInput)
            {
                cameraSway.SwayPlayer(_inputVector,_rawXInput);
            }

            void HandleZoom()
            {
                if(camInputData.ZoomClicked || camInputData.ZoomReleased)
                    cameraZoom.ChangeFOV(this);

            }

            public void ChangeRunFOV(bool _returning)
            {
                cameraZoom.ChangeRunFOV(_returning,this);
            }

            void ChangeCursorState()
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        #endregion
    }
}
