using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPivotRotation : MonoBehaviour {
	public float maxrot = 30f;
	public float minrot = 0f;

	Rigidbody2D rb2D;
	void Awake(){
		rb2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float rotz = rb2D.rotation;
		float rotz2 = Mathf.Clamp (rotz, minrot, maxrot);
		rb2D.rotation = rotz2;
	}
}
