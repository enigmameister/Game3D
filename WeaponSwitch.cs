using UnityEngine;
using TMPro; 
public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon;
    public string weaponName;
    public Pickup pick;

    public bool picked = false;
    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

      
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0; // Hands
                weaponName = "Hands";
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 1 && pick.equip && picked)
            {
                selectedWeapon = 1; // Pistol
                weaponName = "Pistol";
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2 && pick.equip && picked)
            {
                selectedWeapon = 2;  // Riffle
                weaponName = "Riffle";
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 3 && pick.equip && picked)

            {
                selectedWeapon = 3;  // AK47
                weaponName = "AK47";
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 4 && pick.equip & picked)
            {
                selectedWeapon = 4; // AWP
                weaponName = "AWP";
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
    