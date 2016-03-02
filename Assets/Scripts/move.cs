using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public Vector2 speed = new Vector2(10,10);
	//private Vector3 movement;
	private Vector3 rot;
	private Vector3 movementForce;
	//private Quaternion rotation;

	private Rigidbody rigid;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		/*movement = new Vector3(
			0,rigid.velocity.y,	speed.y * inputY);
			/*speed.x * inputX,rigid.velocity.y,
			speed.y * inputY);*/

		movementForce = new Vector3 (0, 0, speed.y * inputY);

		rot = new Vector3(0,speed.x * inputX,0);
		//rotation = Quaternion.AngleAxis (speed.x * inputX, new Vector3(0,1,0));	
		//rotation = new Quaternion (0,speed.x * inputX, 0, 0);


	
	}

	void FixedUpdate(){
		//rigid.velocity = movement;
		rigid.AddRelativeForce (movementForce);
		rigid.angularVelocity = rot;

		//rigid.rotation = rotation;
		//rigid.MoveRotation(rotation);

	}



}
