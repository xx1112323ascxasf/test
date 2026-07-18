using UnityEngine;

public class RaycastWeapon : MonoBehaviour, IWeapon
{
    public float damage = 25f;
    public float knockback = 5f;

    //make raycast visible 

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
