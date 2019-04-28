using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponsHandler[] weapones;

    private int current_Weapon_Index;
    // Start is called before the first frame update
    void Start()
    {
        current_Weapon_Index = 0;
        weapones[current_Weapon_Index].gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TuenOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TuenOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TuenOnSelectedWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TuenOnSelectedWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TuenOnSelectedWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TuenOnSelectedWeapon(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TuenOnSelectedWeapon(6);
        }
        

    }

    void TuenOnSelectedWeapon (int weapon_Index)
    {
        if (current_Weapon_Index == weapon_Index)
            return;
        weapones[current_Weapon_Index].gameObject.SetActive(false);
        weapones[weapon_Index].gameObject.SetActive(true);
        current_Weapon_Index = weapon_Index;
    }

    public WeaponsHandler GetCurrentSelectedWeapon()
    {
        return weapones[current_Weapon_Index];
    }
}
