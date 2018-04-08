using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int lives = 3;
	[SerializeField]
	float maxHealth = 100;

	AudioSource aud;
	[SerializeField]
	AudioClip itHurts;
	[SerializeField]
	AudioClip Kill;

	float health;
	public bool isDead;

	PlayerController pc;
	Animator anim;

	// Use this for initialization
	void Awake () {
		pc = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
		health = maxHealth;
		aud = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			isDead = true;
			pc.enabled = false;
			health = maxHealth;
			lives -= 1;
			anim.Play ("Dying");
			aud.clip = Kill;
			aud.Play ();

			//TODO: Death anim stuff
		}
	}

	public void refresh(){
		isDead = false;
		anim.Play ("Idle");
		if (!pc.enabled) {
			pc.enabled = true;
		}
	}
		
	public void hurtMe(float damage){
		if (isDead)
			return;
		aud.clip = itHurts;
		aud.Play ();
		health -= damage;
	}
}
