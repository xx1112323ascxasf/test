using UnityEngine;

namespace RetroThirdPerson
{


    public class RetroPlayerMovement
    {
        //movement speeds 
        public float speed;

        float currentSpeed; 
        float gravity = 20f;
        float walkSpeed = 1.5f;
        float runSpeed = 4f;
        float backSpeed = 0.5f; 
        float turnSpeed = 150f; 

        float horizontalInput;
        float verticalInput;

        public bool isWalking;
        bool runPressed;
        public bool isRunning;

        //reference
        // Player player;
        // CharacterController characterController;
        // GameObject gameCamera; 

        void Start()
        {
            // player = GetComponent<player>; 
        }

    }

}
