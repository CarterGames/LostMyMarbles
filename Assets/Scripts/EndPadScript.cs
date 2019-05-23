using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPadScript : MonoBehaviour
{

	public GameObject Marble;

	private CameraController CamCtrl;


    void Start()
    {
		CamCtrl = Camera.main.GetComponentInParent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			// Freezes the Camera
			CamCtrl.CamEnabled = false;

			// Freezes the Marbles Position
			Marble.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

			// Rotates the camera around the Marble
			
		}
	}
}
