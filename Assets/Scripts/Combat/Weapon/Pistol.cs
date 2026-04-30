using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : Gun
{
    [Header("Pistol Settings")]
    public float fireRate = 0.5f; // Time between shots
    public float range = 100f; // Maximum range of the pistol
    public Transform muzzle; // Point from which the raycast originates

    private float nextFireTime = 0f;

    void Update()
    {
        // Check for fire input (left mouse button)
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Determine the direction of the shot
        Vector3 shootDirection = muzzle != null ? muzzle.forward : transform.forward;
        Vector3 shootOrigin = muzzle != null ? muzzle.position : transform.position;

        // Perform raycast
        RaycastHit hit;
        if (Physics.Raycast(shootOrigin, shootDirection, out hit, range))
        {
            // Check if the hit object has a HitBox component
            HitBox hitBox = hit.collider.GetComponent<HitBox>();
            if (hitBox != null)
            {
                // Calculate direction for knockback (towards the hit point)
                Vector3 direction = (hit.point - shootOrigin).normalized;
                hitBox.OnRaycastHit(this, direction);
            }
        }

        // Optional: Add muzzle flash, sound, etc. here
    }
}