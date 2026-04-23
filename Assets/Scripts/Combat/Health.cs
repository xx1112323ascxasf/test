using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    [HideInInspector]
    public float currentHealth;
    Ragdoll ragdoll;
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;

        var rigitBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigitBody in rigitBodies)
        {
            HitBox hitBox = rigitBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this; // adding to all parts of hitbox, dont need to apply manually to every part of the aienemy
        }
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    {
        ragdoll.ActivateRagdoll();
    }
}
