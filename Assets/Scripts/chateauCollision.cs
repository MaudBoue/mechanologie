using UnityEngine;
using System.Collections;

public class chateauCollision : MonoBehaviour {

	public GameObject particuleCollision;
	private float coolDownColision = 1;
	private float timeNextColl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coll ) {
		Debug.Log("coll");
		if (coll.gameObject.tag == "Player") {
			Instantiate (particuleCollision, 
			             new Vector3 (coll.transform.position.x, Mathf.Clamp(coll.transform.position.y,this.transform.position.y-1,this.transform.position.y+1), 
			             coll.transform.position.z), this.transform.rotation);
			timeNextColl = Time.time + coolDownColision;
		}
	}

}
