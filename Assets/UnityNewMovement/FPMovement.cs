using FirstPerson;
using Mono.Cecil.Cil;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

namespace FirstPerson
{
    public class FPMovement : MonoBehaviour
    {
        private Rigidbody fpRigitBody;

    

        #region Movement

        public void Awake()
        {
            fpRigitBody = GetComponent<Rigidbody>();

        }
        public void Jump()
        {
            Debug.Log("Jump");
            fpRigitBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        public void Movement()
        {
            
        }

        #endregion

    }
}
