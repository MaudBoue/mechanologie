using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 distancePerso = new Vector3(0,3.29f,-10);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (target) {	
			Vector3 destination = new Vector3 (target.position.x, target.position.y + distancePerso.y, target.position.z + distancePerso.z);
			transform.position = destination;
		}
	
	}
}
