using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	[SerializeField]
	List<GameObject> inventory;
	// Use this for initialization
	void Awake () {
		reset ();
	}
	
	// Update is called once per frame
	public void add(GameObject item){
		inventory.Add (item);
	}

	public void reset(){
		inventory = new List<GameObject> ();
	}
		
}
