using UnityEngine;
using System;

public class Weapon : UnityEngine.Object{
    public static readonly float CharacterFireBufferDistance = 2;
    public float fireSpeed { get; set; }
    public float lastFiredTime { get; set; }
    public float speed { get; set; }
    public Transform ammoPrefab { get; set; }
    public Transform character { get; set; }

    public Weapon(float fireSpeed, float speed, Transform character, Transform ammoPrefab) {
        this.fireSpeed = fireSpeed;
        this.speed = speed;
        this.ammoPrefab = ammoPrefab;
        this.character = character;
    }

    public void onUpdate(){
        if(Input.GetMouseButtonDown(InputNames.MOUSE_LEFT)){
            fire();
        }
    }

    private void fire(){
        //Mouse Data
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 realtiveMousePosition = Input.mousePosition - screenCenter;

        //Ammo rotation
        float realtiveMouseAngle = Mathf.Rad2Deg * Mathf.Atan(realtiveMousePosition.y / realtiveMousePosition.x);

        int mouseAngleQuadrant = 3;
        if(realtiveMousePosition.x >= 0 && realtiveMousePosition.y >= 0){
            mouseAngleQuadrant = 1;
        } else if(realtiveMousePosition.x >= 0 && realtiveMousePosition.y < 0){
            mouseAngleQuadrant = 4;
        } else if(realtiveMousePosition.x < 0 && realtiveMousePosition.y >= 0){
            mouseAngleQuadrant = 2;
        }

        if(mouseAngleQuadrant == 1 || mouseAngleQuadrant == 4){
            realtiveMouseAngle = 90 - realtiveMouseAngle;
        } else if(mouseAngleQuadrant == 2){
            realtiveMouseAngle = 360 - (90 + realtiveMouseAngle);
        } else if(mouseAngleQuadrant == 3){
            realtiveMouseAngle = 270 - realtiveMouseAngle;
        }

        Vector3 worldMouseAngle = new Vector3(0, realtiveMouseAngle, 0);

        Vector3 ammoEulerRotation = ammoPrefab.rotation.eulerAngles + worldMouseAngle;

        if(ammoEulerRotation.y >= 360){
            ammoEulerRotation.y -= 360;
        }

        //Ammo Position
        float realtiveAmmoPositionX = CharacterFireBufferDistance * Mathf.Cos(realtiveMouseAngle);
        float realtiveAmmoPositionZ = CharacterFireBufferDistance * Mathf.Sin(realtiveMouseAngle);
        Vector3 realtiveAmmoPosition = new Vector3(realtiveAmmoPositionX, 0, realtiveAmmoPositionZ);

        Vector3 worldAmmoPosition = character.position + realtiveAmmoPosition;

        //Spawn ammo
        Debug.Log(ammoEulerRotation);
        Instantiate(ammoPrefab, worldAmmoPosition, Quaternion.Euler(ammoEulerRotation));
    }
}

