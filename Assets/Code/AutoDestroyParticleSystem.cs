using UnityEngine;
using System.Collections;

public class AutoDestroyParticleSystem : MonoBehaviour {
	void Start () {
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
	}
}
