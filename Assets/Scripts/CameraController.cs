using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Marble;
	public GameObject MarbleForward;

	public float RotSpdUpDown;
	public float RotSpdLeftRight;


	private Vector3 MouseOrgion;

	private void Update()
	{
		// New Vector3 for the new position when it gets updated
		Vector3 NewPos = Marble.transform.position;

		// Sets the new position
		transform.position = NewPos;
		MarbleForward.transform.position = NewPos;

		// Allows the player to rotate the camera via mouse input   Input.GetAxis("Mouse X") * RotSpdLeftRight    Input.GetAxis("Mouse Y") * RotSpdUpDown

		transform.rotation += Quaternion.Euler(Input.GetAxis("Mouse Y") * RotSpdUpDown, Input.GetAxis("Mouse X") * RotSpdLeftRight, 0);



		MarbleForward.transform.localRotation = Quaternion.Euler(0, Input.mousePosition.x / 20, 0);
	}
}
