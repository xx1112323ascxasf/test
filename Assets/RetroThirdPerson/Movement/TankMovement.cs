using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TankMovement : MonoBehaviour

{
    public float moveSpeed = 5f;

    void Update()
    {
        // Check for forward input (W or UpArrow)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}