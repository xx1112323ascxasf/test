using UnityEngine;

namespace RetroThirdPerson
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonMovement : MonoBehaviour
    {


        private Rigidbody m_Rigitbody;
        Vector3 m_EulerAngleVelocity;


        void Start()
        {
            m_Rigitbody = GetComponent<Rigidbody>();
            if (m_Rigitbody == null)
            {
                Debug.LogError("NoRigitBoddy");
            }

            // actual movement
            m_EulerAngleVelocity = new Vector3(0, 2, 1);

        }

        void FixedUpdate()
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            m_Rigitbody.MoveRotation(m_Rigitbody.rotation * deltaRotation);

        }
    }
}  