using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool canAttack = true;
    public float StopDuration = 2f;

    void OnEnable()
    {
        // Subscribe to detection events
        RayCastForEnemy.OnPlayerDetected += StopAndAttack;
        RayCastForEnemy.OnPlayerLost += ResumePatrol;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        RayCastForEnemy.OnPlayerDetected -= StopAndAttack;
        RayCastForEnemy.OnPlayerLost -= ResumePatrol;
    }

    void StopAndAttack()
    {
        Debug.Log("Enemy stopping and attacking!");
        // Stop enemy movement
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        // Trigger attack animation
        GetComponent<Animator>().SetTrigger("Attack");
    }

    void ResumePatrol()
    {
        Debug.Log("Enemy resuming patrol!");
        // Resume patrol behavior
    }
}