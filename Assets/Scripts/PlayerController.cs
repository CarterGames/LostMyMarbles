using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MoveSpeed = 20;

	[Range(0,50)]
	public float JumpHeight;
	public float FallSpeed;

	[Range(0, 15)]
	public float SpeedFalloff = 15;
	public float SpeedReductionRate;
	public float FallOffDelay;

	private GameObject MoveDirGO;

	private Vector3 StartPos;

	private bool IsFalloffRunning;

	private void Start()
	{
		MoveDirGO = GameObject.FindGameObjectWithTag("CameraPoint");
	}


	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Jump Pressed");
			GetComponent<Rigidbody>().velocity += Vector3.up * JumpHeight;
		}

		Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		Movement = MoveDirGO.transform.TransformDirection(Movement);

		GetComponent<Rigidbody>().AddForce(Movement * MoveSpeed);

		JumpSmoothing();
		HideMouse();
	}


	private void JumpSmoothing()
	{
		//if (GetComponent<Rigidbody>().velocity.y < 0)
		//{
			GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (FallSpeed - 1) * Time.deltaTime;
		//}
		//else if (GetComponent<Rigidbody>().velocity.y > 0 && !Input.GetButton("Jump"))
		//{
		//	GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (JumpHeight - 1) * Time.deltaTime;
		//}
	}


	// Just hides the mouse cursor when playing the game
	private void HideMouse()
	{
		Cursor.visible = false;
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "OutOfBounds")
		{
			Debug.Log("Out Of Bounds");
		}
	}
}
