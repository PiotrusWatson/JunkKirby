using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour {
	[SerializeField]
	float damage = 4;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void OnTriggerStay2D(Collider2D c) {
		
		if (c.gameObject.CompareTag ("PlayerBody")) {
			c.GetComponentInParent<PlayerHealth> ().hurtMe (damage);

		}
	}
}
