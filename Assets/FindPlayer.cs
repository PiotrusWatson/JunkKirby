using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {

	EvaController eva;
	// Use this for initialization
	void Awake () {
		eva = GetComponentInParent<EvaController> ();
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.CompareTag ("PlayerBody")) {
			eva.seePlayer (c.transform.parent.position);
		}
	}
}
