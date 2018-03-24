using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPivotRotation : MonoBehaviour {
	public float maxrot = 30f;
	public float minrot = 0f;
	
	// Update is called once per frame
	void Update () {
		float rotz = transform.rotation.z;
		rotz = Mathf.Clamp (rotz, 0, 30);
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, rotz);
	}
}
