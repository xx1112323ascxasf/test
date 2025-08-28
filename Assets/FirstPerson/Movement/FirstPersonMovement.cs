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




        private void Start()
        {

        }

        private void Update()
        {

        }
        

        
    }
 

    
}





