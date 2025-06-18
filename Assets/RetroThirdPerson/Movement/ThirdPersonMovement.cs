using System.IO;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace RetroThirdPerson
{

    public class ThirdPersonMovement : MonoBehaviour

    {

        public class MovementSettings
        {
            public float MaxSpeed;
            public float Acceleration;
            public float Deceleration;
            public MovementSettings(float maxSpeed, float accel, float decel)
            {
                MaxSpeed = maxSpeed;
                Acceleration = accel;
                Deceleration = decel;

            }
        }

        [Header("Movement")]
        [SerializeField] private float m_Friction = 6;
        [SerializeField] private float m_Gravity = 20;

        // character friction

        public float m_PlayerFriction = 0;

        private Vector3 m_Moveinput;
        private Transform m_Tran;

         

        























































        // void Update()
        // {
        //     if (Input.GetKey(KeyCode.W))
        //     {
        //         moveDirection = Vector3.forward;
        //         transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //     }

        //     if (Input.GetKey(KeyCode.D))
        //     {
        //         moveDirection = Vector3.right;
        //         transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //     }
        //     if (Input.GetKey(KeyCode.A))
        //     {
        //         moveDirection = Vector3.left;
        //         transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //     }
        //     if (Input.GetKey(KeyCode.S))
        //     {
        //         moveDirection = Vector3.back;
        //         transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //     }

    }
    
}