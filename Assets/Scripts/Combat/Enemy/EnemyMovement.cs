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

    // Behavior toggles
    public bool useAttack = true;
    public bool useChase = true;

    // Timers
    public float attackDuration = 0.5f; // max time in attack state
    public float chaseDuration = 3f;    // time to chase between attacks

    // Patrol settings (one-time patrol after losing sight)
    public float patrolRadius = 6f;
    public float patrolDuration = 3f;

    private EnemyStateMachine stateMachine = new EnemyStateMachine();
    private bool cycleRunning;
    private bool patrolDone = false;

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
            StartCoroutine(BehaviorLoop());
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

    private IEnumerator BehaviorLoop()
    {
        cycleRunning = true;

        while (true)
        {
            if (useAttack)
            {
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
            }
            else if (useChase)
            {
                stateMachine.ChangeState(EnemyState.Chasing);
                Agent.isStopped = false;
                Debug.Log("Enemy: Skipping attack, staying in chase state.");
            }

            // Dodge/Flee removed; patrol will run once when the enemy loses sight

            if (useChase)
            {
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
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }

            if (!CanSeePlayer())
            {
                // Patrol behavior temporarily disabled. Will re-enable later.
                if (!patrolDone)
                {
                    Debug.Log("Enemy: Patrol disabled; skipping patrol.");
                    stateMachine.ChangeState(EnemyState.Idle);
                    patrolDone = true;
                }

                Debug.Log("Enemy: Lost sight after behavior loop, stopping cycle.");
                cycleRunning = false;
                yield break;
            }
        }
    }

    // Dodge and Flee behavior removed; patrol implemented above

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
 

