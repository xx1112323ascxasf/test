using UnityEngine;

using System;

public class RayCastForEnemy : MonoBehaviour
{
    public Transform Player;
    public float DetectionRange = 15f;

    // Create an event that other scripts can subscribe to
    public static event Action OnPlayerDetected;
    public static event Action OnPlayerLost;

    private bool isPlayerDetected = false;

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
                    if (!isPlayerDetected)
                    {
                        isPlayerDetected = true;
                        OnPlayerDetected?.Invoke(); // Trigger event
                        Debug.Log("Player detected!");
                    }
                    return;
                }
            }
        }

        // Player is no longer detected
        if (isPlayerDetected)
        {
            isPlayerDetected = false;
            OnPlayerLost?.Invoke(); // Trigger event
            Debug.Log("Player lost!");
        }
    }
}
