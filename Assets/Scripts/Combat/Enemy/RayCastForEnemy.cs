using UnityEngine;

public class RayCastForEnemy : MonoBehaviour
{
    public Transform Player;
    public float DetectionRange = 15f;

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
                    Debug.Log("Player detected!");
                }
            }
        }
    }   

}