using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectIsGrounded : MonoBehaviour {

	PlayerController pc;
	// Use this for initialization
	void Start () {
		pc = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.CompareTag ("Floor")) {
			pc.isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D c){
		if (c.gameObject.CompareTag ("Floor")) {
			pc.isGrounded = false;
		}
	}
}
