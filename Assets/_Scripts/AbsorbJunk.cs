using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbJunk : MonoBehaviour {

	PlayerInventory playerInv;
	// Use this for initialization
	void Awake () {
		playerInv = GetComponentInParent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Grabbable")) {
			playerInv.add (c.gameObject);
			c.gameObject.SetActive (false);

		}
	}
}
