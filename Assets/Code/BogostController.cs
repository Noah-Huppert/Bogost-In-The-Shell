using UnityEngine;
using System.Collections;

public class BogostController: MonoBehaviour {
    public Transform ammoPrefab;
    /*public GameObject ammo;
    public float fireSpeed = 1;//Fire every 1 seconds
    public float lastFired = 0;
    public int ammoSpeed = 10;*/
    public Weapon bullet;

    public float speed = 10;

	public void Start () {
        bullet = new Weapon(1, 10, transform, ammoPrefab);
	}

    public void Update(){
        /*
         * Movement:
         *      Horizontal: X Axis
         *      Elevation: Y Axis
         *      Vertical: Z Axis
         */
        CharacterController characterController = GetComponent<CharacterController>();
        Vector3 characterMotionVector3 = new Vector3(Input.GetAxis(InputNames.HORIZONTAL), 0, Input.GetAxis(InputNames.VERTICAL));
        characterController.SimpleMove(characterMotionVector3 * speed);

        /* Weapons */
        bullet.onUpdate();
    }

    /*
	void Update () {
        //Movement
        CharacterController characterController = GetComponent<CharacterController>();

        Vector3 moveDir = new Vector3(Input.GetAxis(InputNames.HORIZONTAL), 0, Input.GetAxis(InputNames.VERTICAL));

        characterController.SimpleMove(speed * moveDir);

        //Firing
        if(Input.GetMouseButton(InputNames.MOUSE_LEFT) && Time.fixedTime - lastFired >= fireSpeed) {
            lastFired = Time.fixedTime;

            //Bullet rotation
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Vector3 clickOffset = Input.mousePosition - screenCenter;

            float bulletAimRotation = Mathf.Rad2Deg * Mathf.Atan(clickOffset.y / clickOffset.x);
            Vector3 bulletAimVector3 = new Vector3(0, bulletAimRotation, 0);

            Vector3 selfRotationVector3 = transform.rotation.eulerAngles;
            Debug.Log(transform.rotation.eulerAngles);
            Quaternion bulletRotation = Quaternion.Euler(bulletAimVector3 + selfRotationVector3);

            Vector3 ammoSpawnLoc = this.gameObject.transform.position;
            ammoSpawnLoc.x += 1;

            //Spawn bullet
            GameObject ammoClone = Instantiate(ammo, ammoSpawnLoc, bulletRotation) as GameObject;
            ammoClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, ammoSpeed);
        }
	}*/
}
