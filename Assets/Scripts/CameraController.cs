using UnityEngine;

public class CameraController : MonoBehaviour
{
	// References to the Marble and Marble forward which determins the foward direction for movement
	public GameObject Marble;
	public GameObject MarbleForward;

	// Rotation speeds, controls how fast the mouse movement is
	public float RotSpdUpDown;
	public float RotSpdLeftRight;

	// Bool used to disable this script partially when the player hits the end pad
	internal bool CamEnabled;


	private void Start()
	{
		// Sets the camera to be enabled by default
		CamEnabled = true;
	}

	private void Update()
	{
		// New Vector3 for the new position when it gets updated
		Vector3 NewPos = Marble.transform.position;

		// Sets the new position
		transform.position = NewPos;
		MarbleForward.transform.position = NewPos;

		// Allows the player to rotate the camera via mouse input
		if (CamEnabled)
		{
			transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * RotSpdUpDown, Input.GetAxis("Mouse X") * RotSpdLeftRight, 0);
		}

		transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
	

		// Updates the forward position for the players movement
		MarbleForward.transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * RotSpdLeftRight, 0);

		Camera.main.transform.localPosition = new Vector3(/*Camera.main.transform.localPosition.x*/ 0, 2, -7);
		Camera.main.transform.localRotation = Quaternion.Euler(15, 0, 0);
	}
}
