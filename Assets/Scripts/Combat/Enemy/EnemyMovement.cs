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
    public float minStopTime = 1f;
    public float maxStopTime = 3f;

    private bool isStopping;

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
        WaitForSeconds wait = new WaitForSeconds(UpdateSpeed);
        while (enabled)
        {
            if (!isStopping && Target != null)
            {
                Agent.SetDestination(Target.position);
            }

            yield return wait;
        }
    }

    private void FixedUpdate()
    {
        Raycast();
    }

    #region hide

    public void Raycast()
    {
        if (EnemyRayCast == null || isStopping)
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
                    StartCoroutine(StopForRandomTime());
                }
            }
        }
    }

    private IEnumerator StopForRandomTime()
    {
        isStopping = true;
        Agent.isStopped = true;

        float stopDuration = Random.Range(minStopTime, maxStopTime);
        yield return new WaitForSeconds(stopDuration);

        Agent.isStopped = false;
        isStopping = false;
    }

    #endregion
}

