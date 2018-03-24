using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour {

	FixedJoint2D joint;
	// Use this for initialization
	void Awake () {
		joint = GetComponent<FixedJoint2D> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D c){
		Rigidbody2D otherRigidbody = c.gameObject.GetComponent<Rigidbody2D> ();
		if (c.gameObject.CompareTag ("Grabbable") && otherRigidbody != null) {
			c.gameObject.GetComponent<Collider2D> ().isTrigger = true;
			joint.connectedBody = otherRigidbody;


		}
	}
}
