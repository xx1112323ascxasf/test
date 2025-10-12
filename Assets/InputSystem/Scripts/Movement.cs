using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{ 
    //add to inspector 
     public InputActionReference fire;
    public InputActionReference move;

    public SpeedTreeWindAsset force; 

    public void Dash(InputAction.CallbackContext context)
    {
        // B KEY 
        Debug.Log("SussyBaka");
    }
}  
