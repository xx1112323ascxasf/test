using UnityEngine;

public class LowGroundCheck : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * maxDistance, boxSize);
    }


    public bool IsLowGrounded()
    {
        if(Physics.BoxCast(transform.position,boxSize,-transform.up,transform.rotation,maxDistance,layerMask)) //1 center, 2 size, 3 diraction 
        {
            return true;
            

        }   

        else
        {
            return false;
        }      
         
    }
}
