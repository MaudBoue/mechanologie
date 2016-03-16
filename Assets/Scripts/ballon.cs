using UnityEngine;
using System.Collections;

public class ballon : MonoBehaviour {

    private /*new*/ Rigidbody rigidbody;
    public float force = 30;

	private tuchTest2 player;
	private float rotationPlayer;

    //Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<tuchTest2> ();
    }

    // Use this for initialization
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            float inputX = Input.GetTouch(0).deltaPosition.x;
            float inputZ = Input.GetTouch(0).deltaPosition.y;

			rotationPlayer = player.getRot();
			Vector3 mouvement = Quaternion.Euler(0,rotationPlayer,0) * new Vector3(inputX * force,1, inputZ * force);
			GetComponent<Rigidbody>().AddForce(mouvement ,ForceMode.Impulse);
                //GetComponent<Rigidbody>().AddForce(Vector3.up * force * 2);
                GetComponent<Rigidbody>().AddTorque(Vector3.right * 10);
            Debug.Log("roule"); 

            }
     
    }

    }
