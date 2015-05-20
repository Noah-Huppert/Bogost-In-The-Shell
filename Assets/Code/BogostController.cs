using UnityEngine;
using System.Collections;

public class BogostController: MonoBehaviour {
    /* Weapon Prefabs */
    public Transform bulletPrefab;

    public WeaponsManager weaponsManager { get; set; }

    public float speed = 10;

	public void Start () {
        weaponsManager = new WeaponsManager(transform);

        weaponsManager.weapons.Add(new Weapon("Bullet", 1, 10, transform, bulletPrefab));
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
        weaponsManager.onUpdate();
    }
}
