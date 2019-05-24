using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPadScript : MonoBehaviour
{

	public GameObject Marble;
	public float RotSpd;

	private CameraController CamCtrl;
	private LevelTimerScript TimeCtrl;
	private bool IsRot;

    void Start()
    {
		CamCtrl = Camera.main.GetComponentInParent<CameraController>();
		TimeCtrl = GameObject.FindGameObjectWithTag("TimeCtrl").GetComponent<LevelTimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRot)
		{
			// Rotates the camera around the Marble
			Camera.main.transform.parent.eulerAngles += new Vector3(0, RotSpd, 0);
		}
    }


	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			// Pauses the timer
			TimeCtrl.StopTimer();

			// Freezes the Camera
			CamCtrl.CamEnabled = false;

			// Freezes the Marbles Position
			Marble.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

			// Enable rotation of the camera
			IsRot = true;

			// Enable Particles
			GetComponentInChildren<ParticleSystem>().Play();
		}
	}
}
