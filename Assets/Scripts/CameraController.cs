using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[Header("Look At")]
	public Transform Target;                    // Gets the target object in the scene and its position in the world

	[Header("Speed For Camera Rotation")]
	public float RotateSpeed;                   // Float for the speed the camera rorates

	[Header("Debugging")]
	public Vector3 MousePos;					// Vector3 for the mouse / cursur position in the world
	public Vector3 PrevMousePos;				// Vector3 for the previous mouse position so it can tell is the mouse has been moved

	private Vector3 Offset;						// Vector3 for the offset between the target and the camera


	// At the start of the game
	void Start()
	{
		Offset = transform.position - Target.transform.position;		// Sets up the offset to be the distance between the target and the camera
	}

	// Every frame
	void FixedUpdate ()
	{

		MousePos = Input.mousePosition;									// Gets the mouse position in the worldand puts it into the Vector3 setup earlier



		if (MousePos.x > (PrevMousePos.x + 100))						// If the mouse has moved right +100 to where it was before 
		{
			Offset += Vector3.right * Time.deltaTime * RotateSpeed;		// Adds the movement to the offset Vector3
			Debug.Log("Right");											// [DEBUG] - Sends a message to the debugging log
			PrevMousePos.x = MousePos.x;								// Updates the Previous Mouse Position Vector3 to the new Mouse Position 
		}
		else if (MousePos.x < (PrevMousePos.x - 100)) 
		{
			Offset += Vector3.left * Time.deltaTime * RotateSpeed;      // Adds the movement to the offset Vector3
			Debug.Log("Left");                                          // [DEBUG] - Sends a message to the debugging log
			PrevMousePos.x = MousePos.x;                                // Updates the Previous Mouse Position Vector3 to the new Mouse Position 
		}



		Debug.Log("No If Statements Active");                           // [DEBUG] - Sends a message to the debugging log
	}


	// At the end of each frame
	void LateUpdate()
	{
		transform.position = Target.transform.position + Offset;		// Moves the Camera to the position of the Target + the offset 
		transform.LookAt(Target);										// Makes the camera look at the Target
	}
}
