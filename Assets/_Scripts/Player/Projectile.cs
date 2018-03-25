using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	Rigidbody2D rb;
	[SerializeField]
	float force = 50f;

	BlockProperties block;
	// Use this for initialization

	void Awake(){

	}
	void Start () {
		rb = GetComponentInChildren<Rigidbody2D> ();
		block = GetComponentInChildren<BlockProperties> ();
		if (block != null) {
			rb.AddForce (force * block.size * transform.right, ForceMode2D.Impulse);
		} else {
			rb.AddForce (force * transform.right, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
