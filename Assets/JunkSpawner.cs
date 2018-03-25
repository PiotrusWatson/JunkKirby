using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : MonoBehaviour {
	[SerializeField]
	float spawnTime = 3f;
	[SerializeField]
	GameObject[] junkList;

	float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= spawnTime) {
			spawnJunk ();
			timer = 0f;
		}

		timer += Time.fixedDeltaTime;
	}

	void spawnJunk(){
		int index = Random.Range (0, junkList.Length);
		Instantiate (junkList [index], transform.position, Quaternion.identity);
	}
}
