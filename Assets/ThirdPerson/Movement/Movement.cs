using UnityEngine;
using UnityEngine.Rendering;

namespace ThirdPerson
{


    public class Movement : MonoBehaviour
    {
        [Header("Moverment")]
        public float moveSpeed;
        float horizontalInput;
        float verctialInput;
        Vector3 moveDirection;

        



        [Header("Reference")]
        public Transform orientation;
        public Transform player;
        public Transform playerObj;
        public Rigidbody rb;

        public float rotationSpeed;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;    
        }

        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verctialInput = Input.GetAxisRaw("Vertical");
        }
        
        private void MovePlayer()
        {
            moveDirection = orientation.forward * verctialInput + orientation.right * horizontalInput;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        void FixedUpdate()
        {
            MovePlayer();  
        }
        void Update()
        {
            MyInput();


                //rotate orientation
            Vector3 viewDir = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;

            float horizontalInput = Input.GetAxis("Horizontal");
            float verctialInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verctialInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

}