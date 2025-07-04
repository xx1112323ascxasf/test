using UnityEngine;

namespace RetroThirdPerson
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonMovement : MonoBehaviour
    {
        Transform cam;
        public float speed = 2;
        public float forwardSpeed = 6f;
        public float sidewaysSpeed = 4f;

        private Rigidbody rb;

        void Start()
        {
            cam = Camera.main.transform;
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Vector3 forwardMovement = cam.forward * Input.GetAxis("Vertical");
            Vector3 horizontalMovement = cam.right * Input.GetAxis("Horizontal");

            Vector3 movement = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            //movement
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            float x = h * sidewaysSpeed;
            float z = v * forwardSpeed;

            Vector3 movement = new Vector3(x, rb.linearVelocity.y, z); // сохраняем вертикальную скорость

            rb.linearVelocity = movement;
        }
    }
}

  
