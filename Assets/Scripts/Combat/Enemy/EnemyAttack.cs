using UnityEngine;



public class RayCastForEnemy : MonoBehaviour
{
    public Transform Player;
    public float DetectionRange = 15f;
    
    // Random stop settings
    public float MinStopInterval = 1f;
    public float MaxStopInterval = 3f;
    
    private float stopTimer = 0f;
    private bool shouldStop = false;

    void FixedUpdate()
    {
        if (Player == null)
            return;

        Vector3 directionToPlayer = Player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= DetectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, DetectionRange))
            {
                if (hit.transform == Player)
                {
                    // Update timer
                    stopTimer -= Time.fixedDeltaTime;
                    
                    // Time to stop randomly
                    if (stopTimer <= 0)
                    {
                        shouldStop = true;
                        stopTimer = Random.Range(MinStopInterval, MaxStopInterval);
                    }
                    else
                    {
                        shouldStop = false;
                    }
                    return;
                }
            }
        }
        
        shouldStop = false;
    }

    public bool ShouldStopAndAttack()
    {
        return shouldStop;
    }
}