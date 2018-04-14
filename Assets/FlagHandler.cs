using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FlagHandler : MonoBehaviour {

	private GameObject player;
	public GameObject playerTemplate;
	[HideInInspector]
	public bool objAClicked = false;
	[HideInInspector]
	public bool objBClicked = false;
	[HideInInspector]
	public Vector3 playerAPos = new Vector3 (0f, -3.52f, -5.42f);
	[HideInInspector]
	public Vector3 playerBPos = new Vector3 (0f, -3.52f, -5.42f);
	[HideInInspector]
	public Quaternion playerARot = new Quaternion (0f, 0f, 0f, 0f);
	[HideInInspector]
	public Quaternion playerBRot = new Quaternion (0f, 0f, 0f, 0f);

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().name == "Init Scene") {
			if (File.Exists ("flags.json")) {
				File.Delete ("flags.json");
			}
			SceneManager.LoadScene ("Scene A");
		}
		if (File.Exists ("flags.json")) {
			StreamReader reader = new StreamReader ("flags.json");
			JsonUtility.FromJsonOverwrite (reader.ReadToEnd (), this);
			reader.Close ();
		} else {
			StreamWriter sw = File.CreateText("flags.json");
			sw.Write (JsonUtility.ToJson (this));
			sw.Close ();
		}
		player = Instantiate (playerTemplate);
		if (SceneManager.GetActiveScene().name == "Scene A") {
			player.transform.position = playerAPos;
			player.transform.rotation = playerARot;
		}
		if (SceneManager.GetActiveScene().name == "Scene B") {
			player.transform.position = playerBPos;
			player.transform.rotation = playerBRot;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "Scene A") {
			playerAPos = player.transform.position;
			playerARot = player.transform.rotation;
		}
		if (SceneManager.GetActiveScene().name == "Scene B") {
			playerBPos = player.transform.position;
			playerBRot = player.transform.rotation;
		}
	}
}
