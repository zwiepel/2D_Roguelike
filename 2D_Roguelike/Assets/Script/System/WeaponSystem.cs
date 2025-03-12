using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject[] weapons; // Liste aller Waffen
    private GameObject activeWeapon;

    private void Start()
    {
        EquipStartingWeapon();
    }

    private void EquipStartingWeapon()
    {
        string weaponName = GetComponent<PlayerCharacter>().GetActiveCharacter().weaponName;

        foreach (GameObject weapon in weapons)
        {
            if (weapon.name == weaponName)
            {
                activeWeapon = Instantiate(weapon, transform);
                Debug.Log($"Waffe ausgerüstet: {weaponName}");
                break;
            }
        }
    }
}
