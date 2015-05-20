using UnityEngine;
using System;
using System.Collections.Generic;

public class WeaponsManager {
    public Transform character { get; set; }

    public List<Weapon> weapons { get; set; }
    public int selectedWeaponIndex { get; set; }

    public WeaponsManager(Transform character) {
        this.character = character;

        weapons = new List<Weapon>();
        selectedWeaponIndex = 0;
    }

    public void onUpdate(){
        if(selectedWeaponIndex <= weapons.Count){
            Weapon selectedWeapon = weapons[selectedWeaponIndex];
            selectedWeapon.onUpdate();
        }
    }
}
