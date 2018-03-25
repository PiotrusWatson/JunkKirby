using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	Camera camera;

	float minX;
	float minY;
	float maxX;
	float maxY;
	public float cameraSpeed;
	public float sizeStuff;
	public Vector3 cameraBuffer;
	public float defaultSize = 10;
	// Use this for initialization
	void Awake () {
		camera = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void LateUpdate () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		FindBoundary (out minX, out minY, out maxX, out maxY, players);
		doCameraWork (minX, minY, maxX, maxY, players);
	}

	void FindBoundary(out float minX, out float minY, out float maxX, out float maxY, GameObject[] players)
	{
		minX = Mathf.Infinity;
		minY = Mathf.Infinity;
		maxX = Mathf.NegativeInfinity;
		maxY = Mathf.NegativeInfinity;

		foreach (GameObject player in players) 
		{
			Vector2 playerPos = player.transform.position;

			if (playerPos.x < minX)
				minX = playerPos.x;
			if (playerPos.y < minY)
				minY = playerPos.y;

			if (playerPos.x > maxX)
				maxX = playerPos.x;
			if (playerPos.y > maxY)
				maxY = playerPos.y;

		}

	} 
	void doCameraWork (float minX, float minY, float maxX, float maxY, GameObject[] players)
	{
		Vector3 cameraCenter = new Vector3 (0f, 0f, transform.position.z);
		Vector3 defaultCam = cameraCenter;
		foreach (GameObject player in players) 
		{
			cameraCenter += new Vector3 (player.transform.position.x, player.transform.position.y, 0.0f);
		}

		Vector3 finalCameraCenter =  new Vector3 (cameraCenter.x / players.Length, cameraCenter.y / players.Length, transform.position.z);


		if (players.Length > 0)
			transform.position = Vector3.Lerp (transform.position, finalCameraCenter, cameraSpeed * Time.deltaTime);
		else
			transform.position = Vector3.Lerp (transform.position, defaultCam, cameraSpeed * Time.deltaTime);


		float sizeX = maxX - minX + cameraBuffer.x;
		float sizeY = maxY - minY + cameraBuffer.y;

		float camSize = (sizeX > sizeY ? sizeX : sizeY); // If sizeX > sizeY, camSize = sizeX, else sizeY

		if (players.Length > 0)
			camera.orthographicSize = Mathf.Lerp (camera.orthographicSize, camSize * sizeStuff, cameraSpeed * Time.deltaTime);
		else
			camera.orthographicSize = Mathf.Lerp (camera.orthographicSize, defaultSize, cameraSpeed * Time.deltaTime);

	}
}
