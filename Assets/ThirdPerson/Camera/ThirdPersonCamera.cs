using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform PlayerObject;
    public Rigidbody rb;

    public float rotationSpeed;

    public void Update()
    {
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;
    }
}
