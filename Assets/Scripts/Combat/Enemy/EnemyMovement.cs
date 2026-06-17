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

    // Timers
    public float attackDuration = 0.5f; // max time in attack state
    public float chaseDuration = 3f;    // time to chase between attacks

    private EnemyStateMachine stateMachine = new EnemyStateMachine();
    private bool cycleRunning;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        stateMachine.ChangeState(EnemyState.Chasing);
        StartCoroutine(FollowTarget());
    }

    private void Update()
    {
        if (EnemyRayCast == null)
            return;

        if (!cycleRunning && CanSeePlayer())
        {
            StartCoroutine(AttackThenChaseLoop());
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(UpdateSpeed);

        while (enabled)
        {
            if (stateMachine.CurrentState == EnemyState.Chasing && Target != null)
            {
                Agent.SetDestination(Target.position);
            }

            yield return wait;
        }
    }

    private IEnumerator AttackThenChaseLoop()
    {
        cycleRunning = true;

        while (true)
        {
            // Attack state with timeout and early exit
            stateMachine.ChangeState(EnemyState.Attacking);
            Agent.isStopped = true;
            Debug.Log("Enemy: Attacking (start)");

            float attackElapsed = 0f;
            while (attackElapsed < attackDuration)
            {
                if (!CanSeePlayer())
                {
                    Debug.Log("Enemy: lost sight during attack, breaking attack early.");
                    break;
                }

                attackElapsed += Time.deltaTime;
                yield return null;
            }

            // Chase for a fixed interval
            stateMachine.ChangeState(EnemyState.Chasing);
            Agent.isStopped = false;
            Debug.Log($"Enemy: Chasing for {chaseDuration:F2} seconds.");

            float elapsed = 0f;
            while (elapsed < chaseDuration)
            {
                if (Target != null)
                    Agent.SetDestination(Target.position);

                elapsed += Time.deltaTime;
                yield return null;
            }

            if (!CanSeePlayer())
            {
                Debug.Log("Enemy: Lost sight after chase, stopping cycle.");
                cycleRunning = false;
                yield break;
            }
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = EnemyRayCast.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > detectionRange)
            return false;

        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hit, detectionRange))
        {
            return hit.transform == EnemyRayCast;
        }

        return false;
    }
}
 

