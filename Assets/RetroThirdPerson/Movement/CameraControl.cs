using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraContol : MonoBehaviour
{
    
 
    public GameObject target;
    private float speedMod = 10.0f;
    private Vector3 point;
 
    void Start ()
    {
        point = target.transform.position;
        transform.LookAt(point);
    }
 
    void Update ()
    {
        transform
    }


}
