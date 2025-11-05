using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
 
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }

}
