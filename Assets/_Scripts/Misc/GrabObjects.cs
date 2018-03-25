using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour {

	[SerializeField]
	float variance = 0.5f;
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D c){
		Rigidbody2D otherRigidbody = c.gameObject.GetComponent<Rigidbody2D> ();
		if (c.gameObject.CompareTag ("Grabbable") && otherRigidbody != null) {
			otherRigidbody.isKinematic = true;
			c.transform.position = transform.position;
			c.transform.SetParent (transform);
			c.transform.localPosition = Vector3.zero;



		}
	}
}
