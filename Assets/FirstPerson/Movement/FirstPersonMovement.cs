using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
namespace FirstPerson
{
    public class FirstPersonMovement : MonoBehaviour
    {

        [Header("Movement")]
        public float movementSpeed;
        public float groundDrag;
        [Header("Grount check")]

        public float playerHeight;
        public LayerMask whatIsGround;
        bool grounded;


        public Transform orientation;

        float horizontalInput;
        float verticalInput;

        Vector3 moveDirection;

        Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;


        }
        private void Update()
        {
            MyInput();
            MovePlayer();
            IsGrounded(); // заменить потом с луча на сферу, т.к будет вызывать проблемы
            SpeedControl();

        }
        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

        }
        private void IsGrounded()
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
            if (grounded)
                rb.linearDamping = groundDrag;
            else
                rb.linearDamping = 0;
        }
        private void MovePlayer()
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }

        private void SpeedControl()
        {
            Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            if (flatVel.magnitude > movementSpeed)
            {
                Vector3 limitedVelocity = flatVel.normalized * movementSpeed;
                rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
            }
            
        }

    }



}

