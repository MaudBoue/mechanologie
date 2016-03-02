using UnityEngine;
using System.Collections;

public class move3 : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10,10);
	private Vector3 movement;
	private float rot;

	private Vector3 rotVect;
	
	private Rigidbody rigid;

	//pour trace avec timer
	private float nextTrace;
	private float deltaTrace = 0.5f;
	private GameObject trace;
	public GameObject tracePlat;
	public GameObject traceSable;
	public GameObject traceEau;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		rot = 0;
		trace = tracePlat;
		creeTraceDePas();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		movement = new Vector3(0,rigid.velocity.y,speed.y * inputY);
		rot += inputX * speed.x;

			/*speed.x * inputX,rigid.velocity.y,
			speed.y * inputY);*/

		//movementForce = new Vector3 (0, 0, speed.y * inputY);

		//rot = new Vector3(0,speed.x * inputX,0);
		//rotation = Quaternion.AngleAxis (speed.x * inputX, new Vector3(0,1,0));	
		//rotation = new Quaternion (0,speed.x * inputX, 0, 0);
		
		// pour trace fake timer:
		if (Time.time >= nextTrace && (inputY != 0))
			creeTraceDePas ();
		
	}
	
	void FixedUpdate(){
		rigid.velocity = Quaternion.Euler(0,rot,0) * movement;	
		rigid.rotation = Quaternion.Euler (0, rot, 0);		
	}
	

	private void creeTraceDePas () {
		nextTrace = Time.time + deltaTrace;
		GameObject newTrace = Instantiate(trace);
		newTrace.transform.position = new Vector3 (transform.position.x,transform.position.y - 0.49f,transform.position.z);
	}

	public void estSurDuPlat () {
		trace = tracePlat;
		Debug.Log ("plat");
	}
	
	public void estSurDuSable () {
		trace = traceSable;
		Debug.Log ("sable");
	}

	public void estDansLeau () {
		trace = traceEau;
		Debug.Log ("eau");
	}

	
}
