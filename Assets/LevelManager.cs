using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TeamUtility.IO;

public class LevelManager : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (InputManager.GetButton ("Jump")) {
			SceneManager.LoadScene ("ExampleScene");
		} else if (InputManager.GetButton("Absorb")){
			SceneManager.LoadScene("TempleOOT");
		}


	}
}
