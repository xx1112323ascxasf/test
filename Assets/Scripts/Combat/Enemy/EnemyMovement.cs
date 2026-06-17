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
    public bool useDodge = false;
    public bool useFlee = false;
    public bool useChase = true;

    // Timers
    public float attackDuration = 0.5f; // max time in attack state
    public float chaseDuration = 3f;    // time to chase between attacks

    // Dodge settings
    public float dodgeDistance = 4f;
    public float dodgeDuration = 0.6f;
    public float dodgeCooldown = 1.5f;
    [Range(0f, 1f)] public float dodgeChance = 0.4f;

    // Flee settings
    public float fleeDistance = 6f;
    public float fleeDuration = 2f;
    public float fleeCooldown = 3f;
    [Range(0f, 1f)] public float fleeChance = 0.2f;

    private EnemyStateMachine stateMachine = new EnemyStateMachine();
    private bool cycleRunning;
    private bool dodgeOnCooldown;
    private bool fleeOnCooldown;

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

            if (useDodge && !dodgeOnCooldown && Random.value < dodgeChance)
            {
                TryDodge();
                yield return new WaitForSeconds(0.05f);
            }

            if (useFlee && !fleeOnCooldown && Random.value < fleeChance)
            {
                TryFlee();
                yield return new WaitForSeconds(0.05f);
            }

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
                Debug.Log("Enemy: Lost sight after behavior loop, stopping cycle.");
                cycleRunning = false;
                yield break;
            }
        }
    }

    // Dodge helpers
    public void TryDodge()
    {
        if (dodgeOnCooldown || EnemyRayCast == null)
            return;

        StartCoroutine(DodgeRoutine());
    }

    private IEnumerator DodgeRoutine()
    {
        dodgeOnCooldown = true;
        stateMachine.ChangeState(EnemyState.Dodge);
        Agent.isStopped = false;

        Vector3 toPlayer = (EnemyRayCast.position - transform.position).normalized;
        Vector3 perp = Vector3.Cross(toPlayer, Vector3.up).normalized;
        perp *= (Random.value > 0.5f) ? 1f : -1f;

        Vector3 targetPos = transform.position + perp * dodgeDistance;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPos, out hit, 2.0f, NavMesh.AllAreas))
            targetPos = hit.position;

        Agent.SetDestination(targetPos);

        float elapsed = 0f;
        while (elapsed < dodgeDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        // After dodge, go to attack if can see, otherwise chase
        if (CanSeePlayer())
            stateMachine.ChangeState(EnemyState.Attacking);
        else
            stateMachine.ChangeState(EnemyState.Chasing);

        StartCoroutine(DodgeCooldownRoutine());
    }

    private IEnumerator DodgeCooldownRoutine()
    {
        yield return new WaitForSeconds(dodgeCooldown);
        dodgeOnCooldown = false;
    }

    public void TryFlee()
    {
        if (fleeOnCooldown || EnemyRayCast == null)
            return;

        StartCoroutine(FleeRoutine());
    }

    private IEnumerator FleeRoutine()
    {
        fleeOnCooldown = true;
        stateMachine.ChangeState(EnemyState.Flee);
        Agent.isStopped = false;

        Vector3 awayFromPlayer = (transform.position - EnemyRayCast.position).normalized;
        Vector3 targetPos = transform.position + awayFromPlayer * fleeDistance;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPos, out hit, 2.0f, NavMesh.AllAreas))
            targetPos = hit.position;

        Agent.SetDestination(targetPos);

        float elapsed = 0f;
        while (elapsed < fleeDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (CanSeePlayer())
            stateMachine.ChangeState(useAttack ? EnemyState.Attacking : EnemyState.Chasing);
        else
            stateMachine.ChangeState(EnemyState.Chasing);

        StartCoroutine(FleeCooldownRoutine());
    }

    private IEnumerator FleeCooldownRoutine()
    {
        yield return new WaitForSeconds(fleeCooldown);
        fleeOnCooldown = false;
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
 

