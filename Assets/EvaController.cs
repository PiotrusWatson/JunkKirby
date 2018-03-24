﻿using System.Collections;
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
	private Transform scanningZone;
	private Rigidbody2D rb2D;
	private Animator anim;
	Vector2 targetDirection;
	Color oldColor;
	// Use this for initialization
	void Awake() {
		body = transform.GetChild (0);
		scanningZone = body.Find ("ScanningZone");
		rb2D = body.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		targetDirection = Vector2.left;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		switch (EvaState) {
		case EVA_IS.PATROLLING:
			anim.Play ("Patrol");
			timer += Time.fixedDeltaTime;

			if (timer >= changeDirectionLimit) {
				timer = 0f;
				targetDirection *= -1;
				flipX (5f);

			}
			rb2D.velocity = targetDirection * patrolSpeed;

			break;
		case EVA_IS.HUNTING:
			SpriteRenderer scannerRenderer = scanningZone.GetComponent<SpriteRenderer> ();
			oldColor = scannerRenderer.color;
			scannerRenderer.color = Color.Lerp (scannerRenderer.color, new Color (255, 0f, 0f, scannerRenderer.color.a), Time.deltaTime * 5f);
			anim.Play ("AttackPrep");
			

			break;
		case EVA_IS.ATTACKING:
			
			break;
		}
	}

	public void seePlayer(Vector2 lastPosition){
		lastPlayerPosition = lastPosition;
		EvaState = EVA_IS.HUNTING;
	}

	void flipX(float flipTime){
		//flips eva :)

		Vector3 theScale = body.localScale;
		Mathf.Lerp(theScale.x, theScale.x *= -1, flipTime * Time.fixedDeltaTime);
		body.localScale = theScale;
	}
		
	public void chasePlayer(){
		rb2D.MovePosition(Vector2.Lerp(rb2D.position, lastPlayerPosition, Time.fixedDeltaTime * 4f));
	}
		
}

