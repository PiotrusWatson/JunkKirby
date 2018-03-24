using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;
public class PlayerController : MonoBehaviour {


	[SerializeField]
	float speed = 5;
	[SerializeField]
	float jumpStrength = 6;


	bool isFacingRight = false;
	bool isJump = true;
	float horizontal;
	[HideInInspector]
	public bool isGrounded = false;

	private Rigidbody2D rb2D;
	Transform wheel;


	// Use this for initialization
	void Awake () {
		wheel = transform.GetChild (1);
		rb2D = wheel.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		horizontal = InputManager.GetAxis ("Horizontal");

		rb2D.velocity = new Vector2 (horizontal * speed, rb2D.velocity.y);

		if (InputManager.GetButton ("Jump")) {
			rb2D.AddForce (Vector2.up * jumpStrength);
			Debug.Log ("hi im jump");
		}

		if (horizontal < 0 && !isFacingRight) {
			flipX (5);
		} else if (horizontal > 0 && isFacingRight) {
			flipX (5);
		}
	}


	void flipX(float flipTime){
		//flips player :)
		isFacingRight = !isFacingRight;

		Vector3 theScale = wheel.localScale;
		Mathf.Lerp(theScale.x, theScale.x *= -1, flipTime * Time.fixedDeltaTime);
		wheel.localScale = theScale;
	}
}
	