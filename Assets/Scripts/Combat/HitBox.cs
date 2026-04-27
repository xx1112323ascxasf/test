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

        health.TakeDamage(weapon.damage, direction);
        if (partRigidbody != null)
        {
            partRigidbody.AddForce(direction * weapon.knockback, ForceMode.Impulse);
        }
    }
}
