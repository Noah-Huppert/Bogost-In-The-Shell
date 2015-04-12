using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject bulletHitExplosion;

    public void OnCollisionEnter(Collision collision){
        float explosionRotation = transform.rotation.x - 180;

        Quaternion bulletHitExplosionRotation = Quaternion.AngleAxis(explosionRotation, new Vector3(1, 0, 0));

        //Instantiate(bulletHitExplosion, transform.position, bulletHitExplosionRotation);

        //Destroy(this.gameObject);
    }
}
