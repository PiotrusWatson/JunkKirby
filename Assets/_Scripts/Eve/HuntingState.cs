using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingState : AiState {

	Color oldColor;
	Transform scanningZone; 
	Transform body;
	SpriteRenderer scannerRenderer;
	Animator anim;
	EvaController eva;
	public HuntingState(GameObject eva): base(eva){}
	// Use this for initialization
	public override void OnStateEnter () {
		anim = AI.GetComponent<Animator> ();
		body = AI.transform.GetChild (0);
		scanningZone = body.Find ("ScanningZone");
		scannerRenderer = scanningZone.GetComponent<SpriteRenderer> ();
		scanningZone.GetComponent<PolygonCollider2D> ().enabled = false;
		oldColor = scannerRenderer.color;

		anim.Play ("AttackPrep");
		eva = AI.GetComponent<EvaController> ();
	}
	
	// Update is called once per frame
	public override void Tick () {
		scannerRenderer.color = Color.Lerp (scannerRenderer.color, new Color (255, 0f, 0f, scannerRenderer.color.a), Time.deltaTime * 5f);
		if (eva.animationOver) {
			eva.SetState (new AttackingState (eva.gameObject));
		}

	}
}
