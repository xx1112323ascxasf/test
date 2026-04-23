using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public Rigidbody[] rigitBodies;
    Animator animator;

    void Start()
    {
        rigitBodies = GetComponentsInChildren<Rigidbody>();
        DeactivateRagdoll();
        animator = GetComponent<Animator>();
    }

    public void DeactivateRagdoll() //while not moving, the hitbox having error shaking, if not kinematic
    {
        foreach(var rigitBody in rigitBodies)
        {
            rigitBody.isKinematic = true;
        }
        animator.enabled = true;
    }

    public void ActivateRagdoll()
    {
        foreach (var rigitBody in rigitBodies)
        {
            rigitBody.isKinematic = false;
        }
        animator.enabled = false;
    }

    //the whole script helping ragdoll colliders to be static 
    //fixing error with raming on the car
}
