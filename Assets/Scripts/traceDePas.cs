using UnityEngine;
using System.Collections;

public class traceDePas : MonoBehaviour {

	private int countToDestroy;
	private MeshRenderer rend;
	private int countToFade = 100;
	private bool hasDestroyedParticle = false;

	// Use this for initialization
	void Start () {
		countToDestroy = 0;
		rend = this.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		countToDestroy += 1;
		if (countToDestroy > countToFade) {
			rend.material.color = new Color (1,1,1,rend.material.color.a - 0.03f);
		}

		if (countToDestroy > 150 && !hasDestroyedParticle) {
			hasDestroyedParticle = true;
			GameObject.Destroy (this.gameObject.transform.GetChild(0).gameObject);
		}

		if (countToDestroy > 400) {
			GameObject.Destroy (this.gameObject);
		}

	}
}
