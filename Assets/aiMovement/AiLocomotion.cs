using UnityEngine;
using UnityEngine.AI;

namespace AiMovement
{
    public class AiLocomotion : MonoBehaviour
    {
        public Transform plaerTransform;
        NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            agent.destination = plaerTransform.position; // Set the destination of the NavMeshAgent to the player's position
        }
    }

}
