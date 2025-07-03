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
        //заставить это работать
        public Transform cameraTransform;
        private Vector3 moveHorizontal = Vector3.zero;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {

        }
    }

}   


