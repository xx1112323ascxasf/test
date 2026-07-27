using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public float projectileSize = 1f;
    public float projectileLifetime = 2f;

    private void OnEnable()
    {
        transform.localScale = Vector3.one * projectileSize;
    }

    public void Initialize(GameObject prefab, float size, float lifetime)
    {
        projectilePrefab = prefab;
        projectileSize = size;
        projectileLifetime = lifetime;
        transform.localScale = Vector3.one * projectileSize;
    }

    public void Launch(Vector3 direction)
    {
        // Visual-only projectile: no physics movement.
    }
}