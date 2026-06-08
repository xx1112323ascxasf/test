using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private float UpdateSpeed = 0.1f; // how frequently to update the path 


    private NavMeshAgent Agent;
    public Transform EnemyRayCast;

   

    public float detectionRange = 15f;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {

        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);
        while (enabled)
        {
            Agent.SetDestination(Target.transform.position);

            yield return Wait;
        }
    }

    //3213123123
    void FixedUpdate()
    {
        Raycast();
    }

   
    #region hide 
   
    public void Raycast()
    {
        
        if (EnemyRayCast == null)
            return;

        Vector3 directionToPlayer = EnemyRayCast.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, detectionRange))
            {
                if (hit.transform == EnemyRayCast)
                {
                    
                    Debug.Log("player detected!");
                }
            }
        }

    }

    #endregion
   
}

