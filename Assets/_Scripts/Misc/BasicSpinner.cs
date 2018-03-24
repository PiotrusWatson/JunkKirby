using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpinner : MonoBehaviour {

	[SerializeField]
	float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * speed * Time.fixedDeltaTime);
	}
}
