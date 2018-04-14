using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBScript : MonoBehaviour {

	public FlagHandler flags;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (flags.objBClicked) {
			this.gameObject.transform.localScale = new Vector3 (2f, 2f, 2f);
		}
	}

	public void OnBeingClicked() {
		flags.objBClicked = true;
	}
}
