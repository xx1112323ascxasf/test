
using UnityEngine;

using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{


    public void MoveForward()
    {
        Debug.Log("Forward");
    }

    private Rigidbody frb;
    private void Start()
    {
        frb = GetComponent<Rigidbody>();
    }

}