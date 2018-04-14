using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAScript : MonoBehaviour {

	public FlagHandler flags;
	public GameObject sphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (flags.objAClicked) {
			sphere.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

	public void OnBeingClicked() {
		flags.objAClicked = true;
	}
}
