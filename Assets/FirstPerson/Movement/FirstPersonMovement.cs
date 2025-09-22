using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
namespace FirstPerson
{
    public class FirstPersonMovement : MonoBehaviour
    {
        public float MovementSpeed;
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

        }
        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertcial");

        }

        private void MovePlayer()
        {
            
        }

    }



}

