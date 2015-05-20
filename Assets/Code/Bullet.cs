using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject bulletHitExplosion;

    public void OnCollisionEnter(Collision collision){
        Vector3 explosionRotation = transform.rotation.eulerAngles - new Vector3(270, 0, 0);

        Quaternion bulletHitExplosionRotation = Quaternion.Euler(explosionRotation);

        Instantiate(bulletHitExplosion, transform.position, bulletHitExplosionRotation);

        Destroy(this.gameObject);
    }
}
