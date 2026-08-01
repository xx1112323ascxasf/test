using UnityEngine;

public class Shotgun : RaycastWeapon
{
    [SerializeField] private WeaponProjectile projectile = new WeaponProjectile();

    private void Update()
    {
        if (Input.GetMouseButtonDown(projectile.mouseButton))
        {
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        if (projectile == null)
            return;

        projectile.Spawn(transform);
    }
}