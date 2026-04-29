using UnityEngine;

using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Gun[] guns;
    private int currentWeaponIndex = 0;
    private Gun currentGun;

    private void Start()
    {
        // Initialize - disable all weapons except the first one
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].gameObject.SetActive(i == 0);
        }
        currentGun = guns[0];
    }

    private void Update()
    {
        HandleWeaponSwitching();
    }

    private void HandleWeaponSwitching()
    {
        // Check for weapon switch input (1, 2, 3 keys)
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SwitchWeapon(0);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SwitchWeapon(1);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SwitchWeapon(2);
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        // Validate index
        if (weaponIndex < 0 || weaponIndex >= guns.Length)
            return;

        // Don't switch if already using this weapon
        if (currentWeaponIndex == weaponIndex)
            return;

        // Deactivate current weapon
        guns[currentWeaponIndex].gameObject.SetActive(false);

        // Activate new weapon
        guns[weaponIndex].gameObject.SetActive(true);
        currentWeaponIndex = weaponIndex;
        currentGun = guns[weaponIndex];
    }

    public Gun GetCurrentGun()
    {
        return currentGun;
    }

    public int GetCurrentWeaponIndex()
    {
        return currentWeaponIndex;
    }
}