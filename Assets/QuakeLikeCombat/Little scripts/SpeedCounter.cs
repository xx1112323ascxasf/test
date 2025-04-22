using UnityEngine;

public class SpeedCalculator : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed; // Units per second

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate distance moved since last frame
        float distance = Vector3.Distance(transform.position, lastPosition);
        
        // Calculate speed (distance / time)
        speed = distance / Time.deltaTime;

        // Update last position
        lastPosition = transform.position;

        // (Optional) Debug
        Debug.Log("Speed: " + speed.ToString("F2") + " units/sec");
    }
}