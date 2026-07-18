using UnityEngine;

using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    // Accept any component in the inspector; must implement IWeapon at runtime
    [SerializeField] private MonoBehaviour[] weapons;
    private IWeapon[] iWeapons;
    private int currentWeaponIndex = 0;
    private IWeapon currentWeapon;

    private void Start()
    {

        // If serialized array missing or contains nulls, try to auto-find any IWeapon in scene
        if (weapons == null || weapons.Length == 0 || System.Array.Exists(weapons, w => w == null))
        {
            var foundAll = FindObjectsOfType<MonoBehaviour>();
            var foundList = new System.Collections.Generic.List<MonoBehaviour>();
            foreach (var m in foundAll)
            {
                if (m is IWeapon)
                    foundList.Add(m);
            }

            if (foundList.Count > 0)
            {
                weapons = foundList.ToArray();
                Debug.Log($"WeaponManager: auto-populated {weapons.Length} weapons from scene.");
            }
        }

        // Validate serialized array
        if (weapons == null || weapons.Length == 0)
        {
            Debug.LogWarning("WeaponManager: no weapons found or assigned in the inspector.");
            return;
        }

        // (currentWeaponIndex clamped later against iWeapons length)

        // Build internal IWeapon array from serialized components and initialize
        var list = new System.Collections.Generic.List<IWeapon>();
        int firstValid = -1;
        for (int i = 0; i < weapons.Length; i++)
        {
            var mb = weapons[i];
            if (mb == null)
                continue;

            var iw = mb as IWeapon;
            if (iw == null)
                continue;

            if (firstValid == -1)
                firstValid = i;

            list.Add(iw);
        }

        if (list.Count == 0)
        {
            Debug.LogWarning("WeaponManager: no IWeapon implementations found in the assigned components.");
            return;
        }

        iWeapons = list.ToArray();

        // Clamp index and set current
        if (currentWeaponIndex < 0 || currentWeaponIndex >= iWeapons.Length)
            currentWeaponIndex = 0;

        currentWeapon = iWeapons[currentWeaponIndex];
        // Deactivate others and activate current
        for (int i = 0; i < iWeapons.Length; i++)
        {
            if (i == currentWeaponIndex)
                iWeapons[i].Activate();
            else
                iWeapons[i].Deactivate();
        }
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
        // Validate internal weapon list
        if (iWeapons == null || iWeapons.Length == 0)
            return;

        // Validate index
        if (weaponIndex < 0 || weaponIndex >= iWeapons.Length)
            return;

        // Don't switch if already using this weapon
        if (currentWeaponIndex == weaponIndex)
            return;

        // Deactivate current
        if (currentWeaponIndex >= 0 && currentWeaponIndex < iWeapons.Length && iWeapons[currentWeaponIndex] != null)
            iWeapons[currentWeaponIndex].Deactivate();

        // Activate new
        if (iWeapons[weaponIndex] != null)
        {
            iWeapons[weaponIndex].Activate();
            currentWeaponIndex = weaponIndex;
            currentWeapon = iWeapons[weaponIndex];
        }
        else
        {
            Debug.LogWarning($"WeaponManager: weapon at index {weaponIndex} is null, cannot switch.");
        }
    }

    public IWeapon GetCurrentGun()
    {
        return currentWeapon;
    }

    public int GetCurrentWeaponIndex()
    {
        return currentWeaponIndex;
    }
}