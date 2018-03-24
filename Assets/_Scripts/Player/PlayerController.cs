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
	private Animator anim;
	Transform wheel;
	Transform body;


	// Use this for initialization
	void Awake () {
		wheel = transform.Find("Wheel").GetChild(0);
		body = transform.Find("Body");
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		horizontal = InputManager.GetAxis ("Horizontal");

		if (isGrounded) {

			rb2D.velocity = new Vector2 (horizontal * speed, rb2D.velocity.y);

		}

		wheel.Rotate (Vector3.forward * -horizontal * 50f);

		if (horizontal < 0 && !isFacingRight) {
			flipX (0.05f);
		} else if (horizontal > 0 && isFacingRight) {
			flipX (0.05f);
		}
	}

	void Update(){
		if (InputManager.GetButton ("Jump") && isGrounded) {
			rb2D.AddForce (Vector2.up * jumpStrength);
		}

		if (InputManager.GetButtonDown ("Grab")) {
			anim.Play ("StartGrab");
		} else if (InputManager.GetButtonUp ("Grab")) {
			anim.Play ("EndGrab");
		}

		if (InputManager.GetButtonDown ("Absorb") && isGrounded) {
			anim.Play ("StartAbsorb");
		} else if (InputManager.GetButtonUp ("Absorb")) {
			anim.Play ("EndAbsorb");
		}

		if (InputManager.GetButton ("Lean")) {
			if (InputManager.GetAxis ("Lean") > 0) {
				body.transform.eulerAngles = new Vector3 (body.transform.eulerAngles.x, body.transform.eulerAngles.y, 15);
			} else {
				body.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, body.transform.eulerAngles.y, -15);
			}
		} //else {
			//body.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
		//}
	}

	void flipX(float flipTime){
		//flips player :)
		isFacingRight = !isFacingRight;

		Vector3 theRot = transform.eulerAngles;
		theRot.y += 180;
		theRot.y = theRot.y % 360;
		//Mathf.Lerp(theRot.y, 180, flipTime * Time.fixedDeltaTime);
		transform.eulerAngles = theRot;
	}
}
	