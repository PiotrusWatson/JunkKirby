using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndKillOnEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.Log (c.name);
		if (c.gameObject.CompareTag ("PlayerBody")) {
			c.gameObject.GetComponentInParent<PlayerHealth> ().hurtMe (999);
		} else if (c.gameObject.CompareTag("Grabbable")){
			Destroy (c.gameObject);
		}
	}
}
