using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyPistol : RaycastWeapon
{
    [Header("Heavy Pistol Settings")]
    public float fireRate = 1.0f; // slower than a standard pistol
    public float range = 120f;
    public Transform muzzle;
    public float chargeTime = 0.5f; // optional charge before shot

    private float nextFireTime = 0f;
    private bool isCharging = false;
    private float chargeStart = 0f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.isPressed)
        {
            if (!isCharging)
            {
                isCharging = true;
                chargeStart = Time.time;
            }
        }

        if (isCharging && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            float held = Time.time - chargeStart;
            FireHeavy(held);
            isCharging = false;
            nextFireTime = Time.time + fireRate;
        }

        // fallback: prevent firing faster than fireRate
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            FireHeavy(0f);
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireHeavy(float chargeHeld)
    {
        Vector3 origin = muzzle != null ? muzzle.position : transform.position;
        Vector3 dir = muzzle != null ? muzzle.forward : transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(origin, dir, out hit, range))
        {
            HitBox hitBox = hit.collider.GetComponent<HitBox>();
            if (hitBox != null)
            {
                // Increase damage and knockback based on charge held (simple multiplier)
                float originalDamage = damage;
                float originalKnockback = knockback;

                float multiplier = 1f + Mathf.Clamp01(chargeHeld / chargeTime);
                damage *= multiplier;
                knockback *= multiplier;

                hitBox.OnRaycastHit(this, (hit.point - origin).normalized);

                // restore
                damage = originalDamage;
                knockback = originalKnockback;
            }
        }

        // Optional effects
    }
}
