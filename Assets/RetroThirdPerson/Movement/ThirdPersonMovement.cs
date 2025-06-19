using System.IO;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace RetroThirdPerson
{

    public class ThirdPersonMovement : MonoBehaviour
{
        public float forwardSpeed = 6f;
        public float sidewaysSpeed = 4f; 

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            
            float x = moveHorizontal * sidewaysSpeed;
            float z = moveVertical * forwardSpeed;

            Vector3 movement = new Vector3(x, 0f, z);

            rb.linearVelocity = movement; 
        }
    }
    
}