using UnityEngine;
using System.Collections;

public class zoneBallon : MonoBehaviour {

	public tuchTest2 codeDeplacement;
	public ballon codeBallon;
	public GameObject halo;

	private tuchTest2 player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<tuchTest2> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider coll) {
	if (coll.gameObject.tag == "Player") {
			codeDeplacement.enabled = false;
			codeBallon.enabled = true;
			halo.SetActive(true);
			Debug.Log ("ballon");
			player.modif = 0.5f;
		}
	}

	void OnTriggerExit (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			codeDeplacement.enabled = true;
			codeBallon.enabled = false;
			halo.SetActive(false);
			Debug.Log ("marche");
			player.modif = 1;
		}
	}


}
