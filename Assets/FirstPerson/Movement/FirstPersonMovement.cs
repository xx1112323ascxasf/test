using UnityEngine;

namespace FirstPerson
{
    public class FirstPersonMovement : MonoBehaviour
    {

        
        public class MovementSettings
        {
            public float MaxSpeed;
            public float Accleration;
            public float Decalarion;

            public MovementSettings(float maxSpeed, float accel, float decel)
            {
                MaxSpeed = maxSpeed;
                Accleration = accel;
                Decalarion = decel;
            }
        }


        //movement
        [SerializeField] private float m_Friction = 6;
        [SerializeField] private float m_Gravity = 20;
        [SerializeField] private float m_Jumpforce = 8;
        //air control
        [SerializeField] float m_AirControl = 0.3f;
        [SerializeField] private MovementSettings m_GroundSettings = new MovementSettings(7, 14, 10);
        [SerializeField] private MovementSettings m_AirSettings = new MovementSettings(7, 2, 2);
        [SerializeField] private MovementSettings m_StrafeSettings = new MovementSettings(1, 50, 50);


        //Return player current speed


        private void Start()
        {

        }

        private void Update()
        {

        }
        

        
    }
 

    
}





