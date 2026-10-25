using UnityEngine;


public class Player3Controller : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float turnSpeed = 10f;
    public Transform cameraTransform;

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v).normalized;

 
        
    }
}