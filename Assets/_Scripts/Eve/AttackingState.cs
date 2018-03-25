using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : AiState {

	Transform body;
	Transform scanningZone;
	Rigidbody2D rb2D;
	Animator anim;
	Vector3 targetDirection;
	float timer = 0f;
	EvaController eva;

	public AttackingState(GameObject eva): base(eva){}
	// Use this for initialization
	public override void OnStateEnter () {
		body = AI.transform.GetChild (0);
		scanningZone = body.Find ("ScanningZone");
		rb2D = body.GetComponent<Rigidbody2D> ();
		anim = AI.GetComponent<Animator> ();
		targetDirection = Vector2.left;
		eva = AI.GetComponent<EvaController> ();

	}

	// Update is called once per frame
	public override void Tick () {
		eva.chasePlayer ();
		timer += Time.fixedDeltaTime;
		if (timer >= eva.angryThreshold) {
			eva.SetState (new PatrollingState (eva.gameObject));
		}
	}
}
