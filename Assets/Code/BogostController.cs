using UnityEngine;
using System.Collections;

public class BogostController: MonoBehaviour {
    public GameObject ammo;
    public float fireSpeed = 1;//Fire every 1 seconds
    public float lastFired = 0;
    public int ammoSpeed = 10;

    public float speed = 10;

	void Start () {
        
	}

	void Update () {
        //Movement
        CharacterController characterController = GetComponent<CharacterController>();

        Vector3 moveDir = new Vector3(Input.GetAxis(InputNames.HORIZONTAL), 0, Input.GetAxis(InputNames.VERTICAL));

        characterController.SimpleMove(speed * moveDir);

        //Firing
        if(Input.GetMouseButton(InputNames.MOUSE_LEFT) && Time.fixedTime - lastFired >= fireSpeed) {
            lastFired = Time.fixedTime;

            Vector3 ammoSpawnLoc = this.gameObject.transform.position;
            ammoSpawnLoc.x += 1;

            Quaternion ammoRotation = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));

            GameObject ammoClone = Instantiate(ammo, ammoSpawnLoc, ammoRotation) as GameObject;

            ammoClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, ammoSpeed);
        }
	}
}
