using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {
	[SerializeField]
	float respawnTime = 3;

	GameObject[] players;
	GameObject[] playerRespawners;
	GameObject[] respawnTimers;
	GameObject winner;

	bool isOver = false;

	// Use this for initialization
	void Awake () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		playerRespawners = GameObject.FindGameObjectsWithTag ("PlayerRespawner");

		//spawn

	}
	
	// Update is called once per frame
	void Update () {
		if (isOver) {
			return;
		}

		List<GameObject> alivePlayers = new List<GameObject> ();
		foreach (GameObject player in players) {

			//handle elimination
			if (player.activeInHierarchy) {
				if (player.GetComponent<PlayerHealth> ().lives > 0) {
					alivePlayers.Add (player);

				} else {
					player.SetActive (false);
				}
			}
			// handle respawning


		}

		if (alivePlayers.Count == 1) {
			winner = alivePlayers [0];
			isOver = true;
		} else if (alivePlayers.Count == 0) {
			isOver = true;
		}
	}

	public void spawnPlayer(GameObject player){
		int chosenSpawner = Random.Range (0, playerRespawners.Length);

	}
}
