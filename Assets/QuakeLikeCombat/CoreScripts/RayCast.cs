using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Rendering;


 
public class ExampleClass : MonoBehaviour

{
    LayerMask layerMask = LayerMask.GetMask("Wall", "Character");

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        { 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); 
            Debug.Log("Did Hit"); 
        }
        else
        { 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white); 
            Debug.Log("Did not Hit"); 
        }

    }

}
 
