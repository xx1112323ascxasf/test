using UnityEngine;

public class testMovement : MonoBehaviour
{

    float speed = 20f;
    private float rbMovement;
    public float rbMOvementSpeed;
    private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>(); 
        rbMovement = gameObject.transform.position.x;
    }
    void FixedUpdate()
    {
        

           
        
    }
}   
