using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponentInChildren<Rigidbody2D> ();
		rb.AddForce (10000 * transform.right, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
