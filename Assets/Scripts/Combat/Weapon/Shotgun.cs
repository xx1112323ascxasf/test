using UnityEngine;

public class Shotgun : RaycastWeapon
{
    [Header("Shotgun Projectile")]
    public WeaponProjectile projectileSettings;
    public Transform firePoint;
    public int pelletCount = 8;
    public float spreadAngle = 12f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (projectileSettings == null || projectileSettings.prefab == null)
            return;

        var spawnPoint = firePoint != null ? firePoint : transform;

        for (int i = 0; i < pelletCount; i++)
        {
            Vector3 direction = spawnPoint.forward;
            direction = Quaternion.Euler(0f, Random.Range(-spreadAngle, spreadAngle), 0f) * direction;

            GameObject projectileObject = Instantiate(projectileSettings.prefab, spawnPoint.position, Quaternion.LookRotation(direction));
            projectileObject.transform.localScale = Vector3.one * projectileSettings.size;

            if (projectileObject.TryGetComponent(out Projectile projectile))
            {
                projectile.Initialize(projectileSettings.prefab, projectileSettings.size, projectileSettings.lifetime);
                projectile.Launch(direction);
            }
        }
    }
}