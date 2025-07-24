using UnityEngine;

namespace RetroThirdPerson
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonMovement : MonoBehaviour
    {


        private Rigidbody rb;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("NoRigitBoddy");
            }

        }

        void FixedUpdate()
        {
            
        }
    }
}