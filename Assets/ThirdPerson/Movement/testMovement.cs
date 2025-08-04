using Unity.Mathematics;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    private float speed = 2f;




    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInpyt = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
