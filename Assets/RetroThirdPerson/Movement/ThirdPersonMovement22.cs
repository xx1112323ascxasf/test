using UnityEngine;

namespace test
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonMovement : MonoBehaviour
    {
        Transform cam;
        public float speed = 40f;
        public float forwardSpeed = 10f;
        public float sidewaysSpeed = 4f;


        private Rigidbody rb;

        void Start()
        {
            cam = Camera.main.transform;
            rb = GetComponent<Rigidbody>();
        }
        void FixedUpdate()
        {
            Vector3 forwardMovement = cam.forward * Input.GetAxis("Vertical");
            //  Vector3 horizontalMovement = cam.right * Input.GetAxis("Horizontal");

            //Vector3 movement = Vector3.ClampMagnitude( forwardMovement + horizontalMovement, 1);z
            Vector3 movement = Vector3.ClampMagnitude( forwardMovement  , 1);
      
            //movement
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");



            //Vector3 tempVect = new Vector3(h, 0, v);
            //tempVect = tempVect.normalized * speed * Time.deltaTime;
            //rb.MovePosition(transform.position + tempVect); 

            float x = h * sidewaysSpeed;
            float z = v * forwardSpeed;

            Vector3 move = new Vector3(x, speed * rb.linearVelocity.y, z); 

            rb.linearVelocity = movement;
            
        }
    }
}