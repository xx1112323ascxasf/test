using Unity.Mathematics;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    private float speed = 2f;
    //private float rotationSpeed = 90.0f;



    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }


    
    }
}
