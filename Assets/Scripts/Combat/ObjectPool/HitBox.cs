using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;
    Rigidbody partRigidbody;

    void Awake()
    {
        partRigidbody = GetComponent<Rigidbody>();
    }

    public void OnRaycastHit(RaycastWeapon weapon, Vector3 direction)
    {
        if (weapon == null || health == null) return;

        OnDamage(weapon.damage, weapon.knockback, direction);
    }

    public void OnDamage(float damageAmount, float knockbackAmount, Vector3 direction)
    {
        if (health == null) return;

        health.TakeDamage(damageAmount, direction);
        if (partRigidbody != null)
        {
            partRigidbody.AddForce(direction * knockbackAmount, ForceMode.Impulse);
        }
    }
}
