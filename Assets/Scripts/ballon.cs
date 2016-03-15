using UnityEngine;
using System.Collections;

public class ballon : MonoBehaviour {

    private new Rigidbody rigidbody;
    private int force = 30;

    //Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("touch");

            float inputX = -Input.GetTouch(0).deltaPosition.x;
            float inputZ = -Input.GetTouch(0).deltaPosition.y;

                GetComponent<Rigidbody>().AddForce(Vector3.up * force * 2);
                GetComponent<Rigidbody>().AddTorque(Vector3.right * 10);
            { Debug.Log("roule"); }

            }
     
    }

    }
