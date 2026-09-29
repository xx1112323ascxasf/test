using UnityEngine;

[System.Serializable]
public class WeaponProjectile
{
    [Header("Projectile Settings")]
    public string projectileName = "ShotgunProjectile";
    public float speed = 20f;
    public float lifeTime = 3f;
    public float spawnOffset = 0.5f;
    public float size = 0.2f;
    public int mouseButton = 0;
    public bool useGravity = false;
    public bool useSphereShape = true;

    public void Spawn(Transform origin)
    {
        if (origin == null)
            return;

        var projectileObject = new GameObject(projectileName);
        projectileObject.transform.position = origin.position + origin.forward * spawnOffset;
        projectileObject.transform.rotation = origin.rotation;

        if (useSphereShape)
        {
            var sphere = projectileObject.AddComponent<SphereCollider>();
            sphere.radius = size;

            var sphereRenderer = projectileObject.AddComponent<MeshRenderer>();
            sphereRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

            var sphereMeshFilter = projectileObject.AddComponent<MeshFilter>();
            sphereMeshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        }

        var rigidbody = projectileObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = useGravity;
        rigidbody.AddForce(origin.forward * speed, ForceMode.VelocityChange);
        projectileObject.transform.localScale = Vector3.one * size;
        projectileObject.AddComponent<ProjectileCollisionDestroyer>();

        if (lifeTime > 0f)
        {
            Object.Destroy(projectileObject, lifeTime);
        }
    }
}

public class ProjectileCollisionDestroyer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

