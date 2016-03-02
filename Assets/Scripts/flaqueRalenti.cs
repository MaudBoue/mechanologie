using UnityEngine;
using System.Collections;

public class flaqueRalenti : MonoBehaviour {

	public float coefRalenti;
	private static GameObject goutesdeau;

	void Awake(){
		goutesdeau = GameObject.Find ("goutesdEau");
	}
	// Use this for initialization
	void Start () {
		goutesdeau.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider coll){
		goutesdeau.SetActive (true);
	}

	void OnTriggerExit(Collider coll){
		goutesdeau.SetActive (false);
	}
}
