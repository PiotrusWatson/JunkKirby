using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVA_IS {PATROLLING, HUNTING, ATTACKING}
public class EvaController : MonoBehaviour {

	[SerializeField]
	EVA_IS EvaState = EVA_IS.PATROLLING;
	[SerializeField]
	float patrolSpeed = 3f;
	[SerializeField]
	float patrolAcceleration = 2f;
	[SerializeField]
	float changeDirectionLimit = 3f;

	Vector2 lastPlayerPosition;
	float timer = 0f;

	private Transform body;
	private Rigidbody2D rb2D;
	Vector2 targetDirection;
	// Use this for initialization
	void Awake() {
		body = transform.GetChild (0);
		rb2D = body.GetComponent<Rigidbody2D> ();
		targetDirection = Vector2.left;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (EvaState) {
		case EVA_IS.PATROLLING:
			timer += Time.fixedDeltaTime;

			if (timer >= changeDirectionLimit) {
				timer = 0f;
				targetDirection *= -1;
				flipX (5f);

			}
			rb2D.velocity = targetDirection * patrolSpeed;
			Debug.Log (timer);
			break;
		case EVA_IS.HUNTING:
			break;
		case EVA_IS.ATTACKING:
			break;
		}
	}

	public void updateLastPosition(Vector2 lastPosition){
		lastPlayerPosition = lastPosition;
	}

	void flipX(float flipTime){
		//flips eva :)

		Vector3 theScale = body.localScale;
		Mathf.Lerp(theScale.x, theScale.x *= -1, flipTime * Time.fixedDeltaTime);
		body.localScale = theScale;
	}
}

