using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	[SerializeField]
	float maxHealth = 100;
	float health;
	bool isDead;

	PlayerController pc;


	// Use this for initialization
	void Awake () {
		pc = GetComponent<PlayerController> ();
		refresh ();

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			isDead = true;
			pc.enabled = false;
			//TODO: Death anim stuff
		}
	}

	public void refresh(){
		isDead = false;
		health = maxHealth;
		if (!pc.enabled) {
			pc.enabled = true;
		}
	}
		
	public void hurtMe(float damage){
		health -= damage;
	}
}
