using UnityEngine;

using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private RaycastWeapon[] guns;
    private int currentWeaponIndex = 0;
    private RaycastWeapon currentGun;

    private void Start()
    {
        // If guns not assigned or contains nulls, try to auto-find RaycastWeapon components in the scene
        if (guns == null || guns.Length == 0 || System.Array.Exists(guns, g => g == null))
        {
            var found = FindObjectsOfType<RaycastWeapon>();
            if (found != null && found.Length > 0)
            {
                guns = found;
                Debug.Log($"WeaponManager: auto-populated {found.Length} weapons from scene.");
            }
        }

        // Validate guns array
        if (guns == null || guns.Length == 0)
        {
            Debug.LogWarning("WeaponManager: no weapons found or assigned in the inspector.");
            return;
        }

        if (currentWeaponIndex < 0 || currentWeaponIndex >= guns.Length)
            currentWeaponIndex = 0;

        // Initialize - disable all weapons except the first non-null one (or the configured index)
        int firstValid = -1;
        for (int i = 0; i < guns.Length; i++)
        {
            if (guns[i] == null)
                continue;

            if (firstValid == -1)
                firstValid = i;

            guns[i].gameObject.SetActive(i == currentWeaponIndex);
        }

        if (firstValid == -1)
        {
            Debug.LogWarning("WeaponManager: all entries in guns are null.");
            return;
        }

        // Ensure currentGun points to a valid gun
        if (guns[currentWeaponIndex] == null)
        {
            currentWeaponIndex = firstValid;
        }
        currentGun = guns[currentWeaponIndex];
    }

    private void Update()
    {
        HandleWeaponSwitching();
    }

    private void HandleWeaponSwitching()
    {
        if (Keyboard.current == null)
            return;
        // Check for weapon switch input (1 and 2 keys for Pistol and Shotgun)
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SwitchWeapon(0);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SwitchWeapon(1);
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        // Validate guns array
        if (guns == null || guns.Length == 0)
            return;

        // Validate index
        if (weaponIndex < 0 || weaponIndex >= guns.Length)
            return;

        // Don't switch if already using this weapon
        if (currentWeaponIndex == weaponIndex)
            return;

        // Deactivate current weapon if valid
        if (currentWeaponIndex >= 0 && currentWeaponIndex < guns.Length && guns[currentWeaponIndex] != null)
        {
            guns[currentWeaponIndex].gameObject.SetActive(false);
        }

        // Activate new weapon if valid
        if (guns[weaponIndex] != null)
        {
            guns[weaponIndex].gameObject.SetActive(true);
            currentWeaponIndex = weaponIndex;
            currentGun = guns[weaponIndex];
        }
        else
        {
            Debug.LogWarning($"WeaponManager: weapon at index {weaponIndex} is null, cannot switch.");
        }
    }

    public RaycastWeapon GetCurrentGun()
    {
        return currentGun;
    }

    public int GetCurrentWeaponIndex()
    {
        return currentWeaponIndex;
    }
}