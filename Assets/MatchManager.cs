using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {
	[SerializeField]
	float respawnTime = 3;

	GameObject[] players;
	GameObject[] playerRespawners;
	float[] respawnTimers;
	GameObject winner;
	[SerializeField]
	bool isOver = false;

	// Use this for initialization
	void Awake () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		playerRespawners = GameObject.FindGameObjectsWithTag ("PlayerRespawner");
		respawnTimers = new float[players.Length];
		//spawn

		

	}
	
	// Update is called once per frame
	void Update () {
		if (isOver) {
			return;
		}

		List<GameObject> alivePlayers = new List<GameObject> ();
		foreach (GameObject player in players) {
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			int playerId = (int)player.GetComponent<PlayerController> ().id;


			//handle elimination
			if (player.activeInHierarchy) {
				if (playerHealth.lives > 0) {
					alivePlayers.Add (player);

				} else {
					player.SetActive (false);
				}
			}
			// handle respawning

			if (playerHealth.isDead && player.activeInHierarchy) {
				if (respawnTimers [playerId] >= respawnTime) {
					respawnTimers [playerId] = 0f;
					spawnPlayer (player);
				} else {
					respawnTimers [playerId] += Time.fixedDeltaTime;
				}
			}


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
		playerRespawners [chosenSpawner].GetComponent<SpawnController> ().spawnPlayer(player);
	}
}
