using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaController : MonoBehaviour {


	public float patrolSpeed = 3f;
	public float patrolAcceleration = 2f;
	public float changeDirectionLimit = 3f;
	public bool animationOver = false;
	public float angryThreshold = 5f;
	public Color oldColour;

	private AiState currentState;
	public Vector2 lastPlayerPosition;
	float timer = 0f;

	private Transform body;
	private Transform scanningZone;
	private Rigidbody2D rb2D;
	private Animator anim;
	Vector2 targetDirection;
	public Color oldColor;

	// Use this for initialization
	void Awake() {
		body = transform.Find("Body");
		rb2D = body.GetComponent<Rigidbody2D> ();
		oldColour = body.transform.Find ("ScanningZone").GetComponent<SpriteRenderer> ().color;
		SetState (new PatrollingState (gameObject));
	}
	void Start(){
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		currentState.Tick ();
	}

	public void seePlayer(Vector2 lastPosition){
		lastPlayerPosition = lastPosition;
		SetState (new HuntingState (gameObject));
	}

	public void flipX(float flipTime){
		//flips eva :)

		Vector3 theScale = body.localScale;
		Mathf.Lerp(theScale.x, theScale.x *= -1, flipTime * Time.fixedDeltaTime);
		body.localScale = theScale;
	}
		
	public void chasePlayer(){
		rb2D.MovePosition(Vector2.Lerp(rb2D.position, lastPlayerPosition, Time.fixedDeltaTime * 4f));
	}

	public void SetState(AiState state) {
		if (currentState != null) {
			currentState.OnStateExit ();

		}

		currentState = state;

		if (currentState != null) {
			currentState.Init ();
			currentState.OnStateEnter ();
		}

	}

	public AiState GetState() {
		return currentState;
	}
		
		
}

