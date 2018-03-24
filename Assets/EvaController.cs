using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVA_IS {PATROLLING, HUNTING, ATTACKING}
public class EvaController : MonoBehaviour {

	[SerializeField]
	EVA_IS EvaState = EVA_IS.PATROLLING;
	[SerializeField]
	float patrolSpeed;
	[SerializeField]
	float changeDirectionLimit = 3f;

	Vector3 lastPlayerPosition;
	float timer = 0f;
	// Use this for initialization
	void Awake() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (EvaState) {
		case EVA_IS.PATROLLING:
			timer += Time.fixedDeltaTime;

			if (timer > changeDirectionLimit) {

			}
			break;
		case EVA_IS.HUNTING:
			break;
		case EVA_IS.ATTACKING:
			break;
		}
	}

	public void updateLastPosition(Vector3 lastPosition){
		lastPlayerPosition = lastPosition;
	}

	void flipX(float flipTime){
		//flips eva :)

		Vector3 theScale = transform.localScale;
		Mathf.Lerp(theScale.x, theScale.x *= -1, flipTime * Time.fixedDeltaTime);
		transform.localScale = theScale;
	}
}

