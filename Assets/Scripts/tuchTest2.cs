using UnityEngine;
using System.Collections;

public class tuchTest2 : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10,10);
	private Vector3 movement;
	private float addedRot;
	private float rot;

	private Vector3 rotVect;

	public float maxRot;
	public float minRot;
	private bool tourne; // pr si le joueur fait expres de tourner,ou si c'est juste qu'il avance pas parfaitement droit
	
	private Rigidbody rigid;

	// pour placer les traces
	private Camera mainCamera;
	private GameObject trace;
	public GameObject tracePlat;
	public GameObject traceSable;
	public GameObject traceEau;
	public float modif = 1;
	
	
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		rot = 0;
		addedRot = 0;
		tourne = false;
		trace = tracePlat;
		mainCamera = GameObject.FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			float inputX = -Input.GetTouch(0).deltaPosition.x;
			float inputZ = -Input.GetTouch (0).deltaPosition.y;	

			movement = new Vector3 (0, rigid.velocity.y, speed.y * inputZ);
			if (inputX > minRot || inputX < -minRot) {
				tourne = true;
			}
			if (tourne)	{
				if (inputX >= 0 ) addedRot = Mathf.Clamp(speed.x * inputX - minRot,0,maxRot);
				if (inputX < 0 ) addedRot = Mathf.Clamp(speed.x * inputX - minRot,-maxRot,0);
				//addedRot = speed.x * inputX;
				rot += addedRot;
			}
				
		} // fin de tuchmove

		// pour glissage volontaire ? var vitesse / truc qui dit si on a courru avant ? : qui enregistre la vitesse ?
		/*if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Stationary && && Input.GetTouch (1).phase == TouchPhase.Stationary) {
		
		}*/

		// pour inertie
		else {
			if ( movement.z != 0) {
				Vector3 velocity = Vector3.zero;
				Vector3 NewMovement = Vector3.SmoothDamp(movement,new Vector3( 0,rigid.velocity.y,0),ref velocity,0.05f);
				movement = new Vector3 (NewMovement.x,rigid.velocity.y,NewMovement.z);
				//float newZ = movement.z - 0.2f * movement.z;
				//movement = new Vector3( 0,rigid.velocity.y,newZ);
				}
			else movement = new Vector3( 0,rigid.velocity.y,0);
			/*if (addedRot != 0) {
				float refFloat = 1;
				addedRot = Mathf.SmoothDamp(addedRot,0,ref refFloat, 0.5f);*/
			
		} 
			
		// commence touché
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			GameObject newTrace = Instantiate(trace);
			Vector3 tuchPosInWordlSpace = mainCamera.ScreenToWorldPoint(new Vector3 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 8.5f) );
			newTrace.transform.position = new Vector3 (tuchPosInWordlSpace.x, transform.position.y - 0.5f, tuchPosInWordlSpace.z);
			}

		// lache touché
		if (Input.touchCount > 0 && Input.GetTouch(Input.touchCount-1).phase == TouchPhase.Ended){
			tourne = false;		
		}

	} // fin Uodate
	
	void FixedUpdate () {
		rigid.velocity = Quaternion.Euler(0,rot,0) * movement * modif;	
		rigid.rotation = Quaternion.Euler (0, rot, 0);	

		/*rigid.AddRelativeForce (movementForce);
		rigid.angularVelocity += rot;*/
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

	public float getRot () {
		return rot; }

}
