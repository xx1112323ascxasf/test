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

    }

    void Update()
    {
        player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
        //может вызывать ошибки
        GameObject gameCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0];

        if (!player.stopInput)
        {
            if (tankControls)
            {
                float h = horizontalInput * Time.deltaTime * turnSpeed;
                float v = verticalInput * Time.deltaTime * speed;

                Move(h, v);
            }
        }
        else
        {
            float h = horizontalInput * Time.deltaTime * speed;
            float v = verticalInput * Time.deltaTime * speed;

            Move(h, v);
        }

    }

}
