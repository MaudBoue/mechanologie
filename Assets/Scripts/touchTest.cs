using UnityEngine;
using System.Collections;

public class touchTest : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10,10);
	private Vector3 rot;
	public float maxRot;
	public float minRot;
	private Vector3 movementForce;

	private Rigidbody rigid;

	public GameObject trace;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Debug.Log ("touché");
			Vector3 touchDeltaPosition = new Vector3 (Input.GetTouch (0).deltaPosition.x, 0, Input.GetTouch (0).deltaPosition.y);
			//transform.Translate (-touchDeltaPosition.x * speed.x, 0, -touchDeltaPosition.z * speed.y);
			float inputX = -Input.GetTouch(0).deltaPosition.x;
			float inputZ = -touchDeltaPosition.z;	
			movementForce = new Vector3 (0, 0, speed.y * inputZ);
			if(inputX > minRot || inputX < -minRot){
				if (speed.x * inputX <= maxRot && speed.x * inputX >= -maxRot){
					rot = new Vector3 (0, speed.x * inputX, 0);
				} 
				else{
					rot = new Vector3 (0, maxRot, 0);}
			}
		} 
		else {
			movementForce = new Vector3( 0,0,0);
			rot = new Vector3 (0,0,0);

			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				GameObject newTrace = Instantiate(trace);
				newTrace.transform.position = new Vector3 (transform.position.x,0,transform.position.z);
			}
		}

		

		


	}

	void FixedUpdate () {
		rigid.AddRelativeForce (movementForce);
		//transform.Translate (movementForce);
		rigid.angularVelocity += rot;
	}
}
