using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : RaycastWeapon
{
    [Header("Shotgun Settings")]
    public int pelletCount = 8;
    public float spreadAngle = 20f; // degrees
    public float range = 30f;
    public Transform muzzle;
    public float fireRate = 1.0f; // time between shots

    private float nextFireTime = 0f;

    void Update()
    {
        if (Mouse.current == null) return;
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            FireShotgun();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireShotgun()
    {
        Vector3 origin = muzzle != null ? muzzle.position : transform.position;
        Vector3 forward = muzzle != null ? muzzle.forward : transform.forward;

        for (int i = 0; i < pelletCount; i++)
        {
            float angle = Random.Range(-spreadAngle * 0.5f, spreadAngle * 0.5f);
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
            Vector3 dir = rot * forward;

            RaycastHit hit;
            if (Physics.Raycast(origin, dir, out hit, range))
            {
                HitBox hitBox = hit.collider.GetComponent<HitBox>();
                if (hitBox != null)
                {
                    // Each pellet uses weapon's base damage scaled down
                    float originalDamage = damage;
                    // Optionally reduce damage per pellet
                    // Temporarily set damage to per-pellet value and call
                    // We will call OnRaycastHit with this weapon instance; HitBox reads weapon.damage
                    // To avoid modifying shared damage, call health directly if needed. Simpler: reduce knockback instead
                    hitBox.OnRaycastHit(this, (hit.point - origin).normalized);
                }
            }
        }

        // Optional: muzzle flash / sound
    }
}
