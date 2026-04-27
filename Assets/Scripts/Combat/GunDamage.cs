using UnityEngine;

public class GunDamage : RaycastWeapon
{
    public Camera fpsCamera;
    public float range = 100f;
    public LayerMask hitLayers = ~0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Camera cam = fpsCamera != null ? fpsCamera : Camera.main;
        if (cam == null) return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, range, hitLayers))
        {
            HitBox hitBox = hit.collider.GetComponent<HitBox>();
            if (hitBox == null && hit.rigidbody != null)
            {
                hitBox = hit.rigidbody.GetComponentInChildren<HitBox>();
            }

            if (hitBox != null)
            {
                hitBox.OnRaycastHit(this, hit.normal * -1f);
            }
        }
    }
}
