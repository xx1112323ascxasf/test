using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Projectile Stats")]
    [Min(0f)] public float damage = 25f;
    [Min(0f)] public float knockback = 5f;
    [Min(0.1f)] public float speed = 60f;
    [Min(0.01f)] public float size = 1f;
    [Min(0.1f)] public float lifeTime = 5f;
    public bool destroyOnImpact = true;
    public LayerMask hitMask = ~0;

    private Rigidbody rb;
    private Vector3 travelDirection = Vector3.forward;
    private bool isLaunched;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.one * size;
        isLaunched = false;
        CancelInvoke(nameof(DisableProjectile));
        Invoke(nameof(DisableProjectile), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DisableProjectile));
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void Configure(float projectileDamage, float projectileKnockback, float projectileSpeed, float projectileSize)
    {
        damage = projectileDamage;
        knockback = projectileKnockback;
        speed = projectileSpeed;
        size = projectileSize;
        transform.localScale = Vector3.one * size;
    }

    public void Launch(Vector3 direction)
    {
        travelDirection = direction.normalized;
        isLaunched = true;

        if (rb != null)
        {
            rb.linearVelocity = travelDirection * speed;
        }
    }

    private void FixedUpdate()
    {
        if (!isLaunched || rb == null)
            return;

        rb.MovePosition(transform.position + travelDirection * speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (!isLaunched || rb != null)
            return;

        transform.position += travelDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleHit(collision.transform);
    }

    private void HandleHit(Transform hitTransform)
    {
        if (!isLaunched)
            return;

        if (!IsInLayerMask(hitTransform.gameObject.layer))
            return;

        var hitBox = hitTransform.GetComponentInParent<HitBox>();
        if (hitBox != null)
        {
            hitBox.OnDamage(damage, knockback, travelDirection);
        }
        else
        {
            var health = hitTransform.GetComponentInParent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage, travelDirection);
            }
        }

        if (destroyOnImpact)
        {
            DisableProjectile();
        }
    }

    private bool IsInLayerMask(int layer)
    {
        return (hitMask.value & (1 << layer)) != 0;
    }

    private void DisableProjectile()
    {
        gameObject.SetActive(false);
    }
}
