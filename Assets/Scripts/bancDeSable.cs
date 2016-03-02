using UnityEngine;
using System.Collections;

public class bancDeSable : MonoBehaviour {

	public float coefRalenti;
	private tuchTest2 perso;
	private move3 persoSansTuch;

	// Use this for initialization
	void Start () {
		perso = GameObject.FindGameObjectWithTag ("Player").GetComponent<tuchTest2> ();
		persoSansTuch = GameObject.FindGameObjectWithTag ("Player").GetComponent<move3> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.tag == "Player") {
			persoSansTuch.estSurDuSable();
			perso.estSurDuSable();
		}
	}

	void OnCollisionExit (Collision coll) {
		if (coll.gameObject.tag == "Player") {
			persoSansTuch.estSurDuPlat();
			perso.estSurDuPlat();
		}
	}

}
