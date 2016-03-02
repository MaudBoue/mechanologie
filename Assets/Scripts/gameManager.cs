using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	
	}


	public void recommencer() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void quitter() {
		Application.Quit();
	}
}
