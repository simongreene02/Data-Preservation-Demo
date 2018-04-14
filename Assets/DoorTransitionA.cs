using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DoorTransitionA : MonoBehaviour {

	public FlagHandler flags;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked() {
		StreamWriter sw = new StreamWriter ("flags.json", false);
		sw.Write (JsonUtility.ToJson (flags));
		sw.Close ();
		SceneManager.LoadScene ("Scene B");
	}
}
