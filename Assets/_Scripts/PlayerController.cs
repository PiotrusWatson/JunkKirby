using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;
public class PlayerController : MonoBehaviour {


	[SerializeField]
	float speed = 5;
	[SerializeField]
	float jumpStrength = 6;


	float horizontal;

	private Rigidbody2D rb2D;


	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		horizontal = InputManager.GetAxis ("Horizontal");
		Debug.Log (horizontal);

		rb2D.velocity = new Vector2 (horizontal * speed, 0f);
	}
}
	