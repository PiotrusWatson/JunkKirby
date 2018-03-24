using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	Vector3 playerPos;
	[SerializeField]
	float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.GetChild (1).localPosition;
		Vector3 newPos = new Vector3 (playerPos.x, playerPos.y, -10f);
		transform.position = Vector3.Lerp (transform.position, newPos, speed * Time.fixedDeltaTime);
	}
}
