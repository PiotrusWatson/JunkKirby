using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	// Use this for initialization
	public void spawnPlayer(GameObject player){
		player.transform.position = transform.position;
		player.GetComponent<PlayerHealth> ().refresh ();
	}
}
