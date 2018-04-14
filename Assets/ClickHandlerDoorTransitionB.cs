using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerDoorTransitionB : MonoBehaviour {

	private bool isMouseOn;
	public DoorTransitionB clickScript;
	[HideInInspector]
	public ClickHandlerDoorTransitionB[] childScripts;

	// Use this for initialization
	void Start () {
		childScripts = new ClickHandlerDoorTransitionB[this.gameObject.transform.childCount];
		for (int i = 0; i < childScripts.Length; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.GetComponent<ClickHandlerDoorTransitionB> () == null) {
				childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.AddComponent<ClickHandlerDoorTransitionB> () as ClickHandlerDoorTransitionB;
			} else {
				childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.GetComponent<ClickHandlerDoorTransitionB> () as ClickHandlerDoorTransitionB;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (this.clickScript != null) {
			if (Input.GetMouseButtonDown (0) && IsMouseOn()) {
				clickScript.OnBeingClicked ();
			}
		}
	}

	void OnMouseEnter () {
		isMouseOn = true;
	}

	void OnMouseExit () {
		isMouseOn = false;
	}

	public bool IsMouseOn() {
		if (isMouseOn) {
			return true;
		}
		for (int i = 0; i < childScripts.Length; i++) {
			if (childScripts [i].IsMouseOn()) {
				return true;
			}
		}
		return false;
	}
}
