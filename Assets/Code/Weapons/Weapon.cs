using UnityEngine;
using System;

public class Weapon : UnityEngine.Object{
    public static readonly float CharacterFireBufferDistance = 2;
    public string name { get; set; }
    public float fireSpeed { get; set; }
    public float lastFiredTime { get; set; }
    public float speed { get; set; }
    public Transform ammoPrefab { get; set; }
    public Transform character { get; set; }

    public Weapon(string name, float fireSpeed, float speed, Transform character, Transform ammoPrefab) {
        this.name = name;
        this.fireSpeed = fireSpeed;
        this.speed = speed;
        this.ammoPrefab = ammoPrefab;
        this.character = character;

        this.lastFiredTime = Time.fixedTime - fireSpeed;
    }

    public void onUpdate(){
        if(Input.GetMouseButtonDown(InputNames.MOUSE_LEFT) && Time.fixedTime - lastFiredTime >= fireSpeed){
            fire();
        }
    }

    private void fire(){
        //Reset fire time
        lastFiredTime = Time.fixedTime;

        //Mouse Data
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 realtiveMousePosition = Input.mousePosition - screenCenter;

        //Ammo rotation
        float realtiveMouseAngle = Mathf.Rad2Deg * Angle.ClockwiseAtan(realtiveMousePosition.y, realtiveMousePosition.x);

        Vector3 worldMouseAngle = new Vector3(0, realtiveMouseAngle, 0);

        Vector3 ammoEulerRotation = ammoPrefab.rotation.eulerAngles + worldMouseAngle;

        //Ammo Position
        float realtiveAmmoPositionZ = CharacterFireBufferDistance * Mathf.Cos(Mathf.Deg2Rad * realtiveMouseAngle);
        float realtiveAmmoPositionX = CharacterFireBufferDistance * Mathf.Sin(Mathf.Deg2Rad * realtiveMouseAngle);
        Vector3 realtiveAmmoPosition = new Vector3(realtiveAmmoPositionX, 0, realtiveAmmoPositionZ);

        Vector3 worldAmmoPosition = character.position + realtiveAmmoPosition;

        //Spawn ammo
        Transform ammoClone = Instantiate(ammoPrefab, worldAmmoPosition, Quaternion.Euler(ammoEulerRotation)) as Transform;
        float velocityYRatio = CharacterFireBufferDistance / realtiveMousePosition.y;
        float velocityXRatio = CharacterFireBufferDistance / realtiveMousePosition.x;

        Vector3 globalAmmoVeolcity = ammoClone.position - character.position;
        globalAmmoVeolcity /= CharacterFireBufferDistance;
        globalAmmoVeolcity *= speed;

        ammoClone.GetComponent<Rigidbody>().velocity = globalAmmoVeolcity;
    }
}

