using UnityEngine;
using System.Collections;

public class bancDeSable : MonoBehaviour {

	public float coefRalenti;
	private tuchTest2 perso;
	private move3 persoSansTuch;
	private Rigidbody persoRigid;
	public Animator camera;

	public float vitesseFall = 50;
	public GameObject traceTombe;
	private float coolDown = 3;
	private float timeNextFall;
	
	// Use this for initialization
	void Start () {
		perso = GameObject.FindGameObjectWithTag ("Player").GetComponent<tuchTest2> ();
		persoSansTuch = GameObject.FindGameObjectWithTag ("Player").GetComponent<move3> ();
		persoRigid = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
		//camera = GameObject.Find ("Spherecam").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	/*if (Time.time < timeNextFall / 2) {
			//perso.modif = 0;

		}*/
		if (Time.time > timeNextFall  && perso.enabled == false){
			perso.enabled = true;
			//camera.SetBool("tombe",false);
		}
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

	void OnCollisionStay (Collision coll){
		if (coll.gameObject.tag == "Player") {
		if ((persoRigid.velocity.x + persoRigid.velocity.z) > vitesseFall && Time.time > timeNextFall) {
				timeNextFall = Time.time + coolDown;
				Instantiate (traceTombe, perso.transform.position, perso.transform.rotation);
				perso.enabled = false;
				persoRigid.velocity = Vector3.zero;
				camera.SetBool("tombe",true);
			}
		}
	}
}
