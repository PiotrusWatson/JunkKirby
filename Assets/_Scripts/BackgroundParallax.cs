using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundParallax : MonoBehaviour
{
	public float parallaxScale;					// The proportion of the camera's movement to move the backgrounds by.
	public float smoothing;						// How smooth the parallax effect should be.
	private Renderer renderer;
	private Transform cam;						// Shorter reference to the main camera's transform.
	private Vector3 previousCamPos;				// The postion of the camera in the previous frame.
	private Vector3 initialCamPos;
	private Vector2 initialOffset;

	void Awake ()
	{
		// Setting up the reference shortcut.
		cam = Camera.main.transform;
	}


	void Start ()
	{
		// The 'previous frame' had the current frame's camera position.
		initialCamPos = cam.position;
		previousCamPos = cam.position;
		renderer = GetComponent<Renderer> ();
		initialOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
	}


	void Update ()
	{
		// The parallax is the opposite of the camera movement since the previous frame multiplied by the scale.
		float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;

		// ... set a target x position which is their current position plus the parallax multiplied by the reduction.
		//float backgroundTargetPosX = backgrounds[i].position.x + parallax * (i * parallaxReductionFactor + 1);

		// Create a target position which is the background's current position but with it's target x position.
		///Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
		//backgrounds[i].GetComponent<Renderer>.get
		// Lerp the background's position between itself and it's target position.
		//backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		float x = Mathf.Repeat((cam.position.x - initialCamPos.x)*parallaxScale,1);
		Vector2 offset = new Vector2(x, 0);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		// Set the previousCamPos to the camera's position at the end of this frame.
		previousCamPos = cam.position;
	}
}