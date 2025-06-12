using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace RetroThirdPerson
{
    public class TankMovement : MonoBehaviour

    {
        public bool tankControls = true;

        public float speed;

        float currentSpeed;
        float gravity = 20f;

        float walkSpeed = 1.5f;
        float runSpeed = 4f;
        float backSpeed = 1f;
        float turnSpeed = 150f;


        float horizontalInput;
        float verticalInput;

        //States
        public bool isWaling;
        bool runPressed;
        public bool isRunning;

        //Reference
        Player player;
        CharacterController characterController;
        GameObject gameCamera;



        void Start()
        {
            player = GetComponent<Player>();
            characterController = GetComponent<CharacterController>();
            //может вызывать ошибки
            GameObject gameCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        }

        void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            runPressed = Input.GetKey(KeyCode.LeftShift);

            if (!player.isAaiming)
            {
                if (horizontalInput > 0)
                {
                    horizontalInput = 1;
                }
                else if (horizontalInput < 0)
                {
                    horizontalInput = -1;
                }
                else
                {
                    horizontalInput = 0;
                }
                if (verticalInput > 0)
                {
                    verticalInput = 1;
                }
                else if (verticalInput < 0)
                {
                    verticalInput = -1;
                }
                else
                {
                    verticalInput = 0;
                }
            }




            if (!player.stopInput)
            {
                if (tankControls)
                {
                    float h = horizontalInput * Time.deltaTime * turnSpeed;
                    float v = verticalInput * Time.deltaTime * speed;

                    //Move(h, v);
                }
            }
            else
            {
                float h = horizontalInput * Time.deltaTime * speed;
                float v = verticalInput * Time.deltaTime * speed;

                //Move(h, v);
            }

        }

        bool movingForward = false;
        bool movingBackward = false; 

        if (verticalInput > 0)
        {
            if (tankControls)
            {
                
            }
        }
    }
}
