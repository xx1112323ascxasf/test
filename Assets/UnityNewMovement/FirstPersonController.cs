using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem

namespace FirstPersonMovement
{
    public class FirstPersonController : MonoBehaviour
    {

        private Rigidbody sphereRigitbody;

        private void Awake()
        {
            sphereRigitbody = GetComponent<Rigidbody>();
        }
        private void Jump()
        {
            sphereRigitbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }


    }
}

