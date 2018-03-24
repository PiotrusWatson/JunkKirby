using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	[SerializeField]
	List<GameObject> inventory;
	// Use this for initialization
	void Awake () {
		inventory = new List<GameObject> ();
	}
	
	// Update is called once per frame
	public void add(GameObject item){
		inventory.Add (item);
	}
		
}
