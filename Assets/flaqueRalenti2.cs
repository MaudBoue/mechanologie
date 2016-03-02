using UnityEngine;
using System.Collections;

public class flaqueRalenti2 : MonoBehaviour {
	
	public float coefRalenti;
	private static GameObject goutesdeau;

	private tuchTest2 perso;
	private move3 persoSansTuch;
	
	void Awake(){
		goutesdeau = GameObject.Find ("goutesdEau");
		perso = GameObject.FindGameObjectWithTag ("Player").GetComponent<tuchTest2> ();
		persoSansTuch = GameObject.FindGameObjectWithTag ("Player").GetComponent<move3> ();
	}
	// Use this for initialization
	void Start () {
		//goutesdeau.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider coll){
		if (coll.gameObject.tag == "Player") {
			persoSansTuch.estDansLeau();
			perso.estDansLeau();
		}
	}
	
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Player") {
			persoSansTuch.estSurDuPlat();
			perso.estSurDuPlat();
		}
	}


}

