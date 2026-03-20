using UnityEngine;
using UnityEngine.AI;

namespace AiMovement
{
    public class AiLocomotion : MonoBehaviour
    {
        public Transform plaerTransform;
        NavMeshAgent agent;
        public float maxTime = 1.0f;
        public float maxDistance = 1.0f;
        Animator animator;
        float timer = 0.0f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            timer -= Time.deltaTime;
            if(timer < 0.0f)
            {
                float sqDistance = (plaerTransform.position - agent.destination).sqrMagnitude;
                if (sqDistance > maxDistance * maxDistance)
                {
                    agent.destination = plaerTransform.position;
                }
                agent.destination = plaerTransform.position;
            }
             // Set the destination of the NavMeshAgent to the player's position
            animator.SetFloat("Speed", agent.velocity.magnitude); 
        }
    }

}
