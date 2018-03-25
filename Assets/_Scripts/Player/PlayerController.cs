using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;
public class PlayerController : MonoBehaviour {


	[SerializeField]
	float speed = 5;
	[SerializeField]
	float jumpStrength = 6;
	[SerializeField]
	float leanSpeed = 5f;

	public PlayerID id = PlayerID.One;

	public GameObject abilityPrefab;
	public GameObject projectilePrefab, junkBlockPrefab;
	private bool isGrabbing = false;

	bool isFacingRight = false;
	bool isJump = true;
	float horizontal;
	[HideInInspector]
	public bool isGrounded = false;

	private Rigidbody2D rb2D;
	private Animator anim;
	Transform wheel;
	Transform body;
	Transform hook;
	PlayerInventory inv;


	// Use this for initialization
	void Awake () {
		wheel = transform.Find("Wheel").GetChild(0);
		body = transform.Find("Body");
		hook = transform.Find("Chain").Find ("Hook");
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		inv = GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		horizontal = InputManager.GetAxis ("Horizontal", id);

		//if (isGrounded) {

		rb2D.velocity = new Vector2 (horizontal * speed, rb2D.velocity.y);

		//}

		wheel.Rotate (Vector3.forward * -horizontal * 50f);



		/*//Useless shit
		float lean = InputManager.GetAxisRaw("Lean", id);
		if (InputManager.GetInputConfiguration (id).name.Contains ("Controller")) {
			rb2D.MoveRotation (Mathf.Lerp (0f, 360f * -lean, Time.deltaTime * leanSpeed));
		} else {
			rb2D.MoveRotation (Mathf.Lerp (0f, 360f * lean, Time.deltaTime * leanSpeed));
		}*/
	}

	void Update(){
		if ((InputManager.GetButtonDown ("Jump", id) && isGrounded)) {
			rb2D.AddForce (Vector2.up * jumpStrength);
		}

		if (InputManager.GetButtonDown ("Grab", id) && !isGrabbing) {
			isGrabbing = true;
			anim.Play ("StartGrab");
		} else if (InputManager.GetButtonUp ("Grab", id)) {
			anim.Play ("EndGrab");
		}

		if (InputManager.GetButtonDown ("Absorb", id) && isGrounded) {
			anim.Play ("StartAbsorb");
		} else if (InputManager.GetButtonUp ("Absorb", id)) {
			anim.Play ("EndAbsorb");
		}

		if (horizontal < 0 && !isFacingRight) {
			flipX (0.05f);
		} else if (horizontal > 0 && isFacingRight) {
			flipX (0.05f);
		}


		if(InputManager.GetButton("Shoot", id)){
			Shoot();
		}

	}

	void Shoot(){
		if (inv) {
			GameObject item = inv.pop ();
			if (item != null) {
				anim.Play ("Shoot");
				GameObject obj = Instantiate (projectilePrefab, body.transform.Find("Barrel").position, body.transform.Find("Barrel").rotation);

				item.SetActive (true);
				item.transform.SetParent (obj.transform);
				item.transform.localPosition = Vector3.zero;
				item.GetComponentInChildren<Rigidbody2D> ().isKinematic = false;
			}
		}

	}

	public void Compact(){
		int counter = inv.inventory.Count;

		foreach (GameObject obj in inv.inventory){
			BlockProperties blockFacts = obj.GetComponent<BlockProperties> ();
			if (blockFacts != null) {
				counter += blockFacts.size;
			}
		}

		if (counter == 0)
			return;
		inv.reset();

		GameObject block = Instantiate(junkBlockPrefab, body.Find("Compactor").position, Quaternion.identity,null);
		block.transform.localScale *= (Mathf.Log (counter) + 1);
		block.GetComponent<BlockProperties> ().size = counter;
		block.GetComponent<Rigidbody2D> ().mass = counter;
	}

	public void CollectGrabbed(){
		foreach(Transform c in hook.GetComponentsInChildren<Transform>()){
			if (c.gameObject.CompareTag ("Grabbable")) {
				inv.add (c.gameObject);
				c.gameObject.SetActive (false);
			}
		}

		isGrabbing = false;
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
	