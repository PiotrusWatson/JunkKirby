using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndKillOnEnter : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("PlayerBody")) {
			c.gameObject.GetComponentInParent<PlayerHealth> ().hurtMe (999);
		} else if (c.gameObject.CompareTag("Grabbable")){
			Destroy (c.gameObject);
		}
	}
}
