using System;
using UnityEngine;

namespace FirstPerson
{
    public class FirstPersonCamera : MonoBehaviour
    {
        public float sensivityX;
        public float sensivityY;

        public Transform orientation;

        float xRotation;
        float yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensivityX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensivityY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Math.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            
        }
    }
}