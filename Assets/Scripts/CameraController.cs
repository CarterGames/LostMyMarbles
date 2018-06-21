using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[Header("Look At")]
	public Transform Target;                    // Gets the target object in the scene and its position in the world

	[Header("Speed For Camera Rotation")]
	public float RotateSpeed;                   // Float for the speed the camera rorates

	private Vector3 OffsetX;                    // Vector3 for the offset between the target and the camera on the X axis
	private Vector3 StartPos;					// Vector3 for the position the camera starts in

	// At the start of the game
	void Start()
	{
		// getting the camera up in the starting position
		StartPos = new Vector3(Target.transform.position.x, Target.transform.position.y + 2, Target.transform.position.z - 5);

		// setting the camera up in the starting position
		transform.position = StartPos;

		// Sets up the offset to be the distance between the target and the camera
		OffsetX = transform.position - Target.transform.position;

	}

	// Every frame
	void Update ()
	{

		// Sets up the angle of rotation on the X axis
		// This sets up and axisangle whih takes the mouse X input multiplies it by RotateSpeed to get the angle of rotation
		// Then using uses a Vector3 to determine the direction of the rotation
		// Finally it is multiplied by the offset to make it releative to the target

		OffsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotateSpeed, Vector3.down) * OffsetX;

	}


	// At the end of each frame

	void LateUpdate()
	{

		// Moves the Camera to the position of the Target + the offset
		transform.position = Target.transform.position + OffsetX;

		// Makes the camera look at the Target
		transform.LookAt(Target);												
	}
	
}