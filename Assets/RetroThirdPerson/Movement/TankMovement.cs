using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

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
                float he = horizontalInput * Time.deltaTime * turnSpeed;
                float ve = verticalInput * Time.deltaTime * speed;

                Move(he, ve);
            }
        }
        else
        {
            float he = horizontalInput * Time.deltaTime * speed;
            float ve = verticalInput * Time.deltaTime * speed;

            Move(he, ve);
        }


        bool movingForward = false;
        bool movingBackward = false;
        if (verticalInput > 0)
        {
            if (movingForward = false)
            {
                movingForward = true;
            }
        }
        else if (verticalInput < 0)
        {
            if (tankControls)
            {
                movingForward = false;
                movingBackward = true;
            }
            {
                movingForward = true;
            }

        }
        else if (!tankControls && horizontalInput != 0)
        {
            movingForward = true;
        }
        else
        {
            movingForward = false;
        }
        if (movingForward && runPressed)
        {
            isRunning = true;
            speed = backSpeed;
        }
        else
        {
            isRunning = false;
            speed = walkSpeed;
        }
    }

    void Move(float he, float ye)
    {
        if (tankControls)
        {
            Vector3 move = new Vector3(0, 0, verticalInput);
            move = transform.TransformDirection(move);
            move.y -= gravity * Time.deltaTime;
            characterController.Move(move);

            Vector3 turn = new Vector3(0, he, 0);
            transform.Rotate(turn);
        }
    }
}