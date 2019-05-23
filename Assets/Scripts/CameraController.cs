using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Marble;
	public GameObject MarbleForward;

	private void Update()
	{
		// New Vector3 for the new position when it gets updated
		Vector3 NewPos = Marble.transform.position;

		// Sets the new position
		transform.position = NewPos;
		MarbleForward.transform.position = NewPos;

		// Allows the player to rotate the camera via mouse input
		if (Input.mousePosition.x >= Screen.width * 0.95)
		{
			Debug.Log("running");
			transform.localRotation *= Quaternion.Euler(0, 10 , 0);
		}
		else
		{
			transform.localRotation = Quaternion.Euler(Input.mousePosition.y / 100, Input.mousePosition.x / 20, 0);
		}

		MarbleForward.transform.localRotation = Quaternion.Euler(0, Input.mousePosition.x / 20, 0);
	}
}
