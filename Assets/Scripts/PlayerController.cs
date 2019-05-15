using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Range(0,10)]
	public float MoveSpeed;

	[Range(0,50)]
	public float JumpHeight;
	public float FallSpeed;

	private Vector3 StartPos;


	private void Start()
	{
		StartPos = transform.parent.position;
	}

	private void Update()
	{

		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Jump Pressed");
			GetComponent<Rigidbody>().velocity += Vector3.up * JumpHeight;
		}


		Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		GetComponent<Rigidbody>().velocity += Movement / MoveSpeed;

		JumpSmoothing();
	}


	private void LateUpdate()
	{
		// Currently breaks the marble
		//transform.parent.position = transform.position - StartPos;
	}

	private void JumpSmoothing()
	{
		if (GetComponent<Rigidbody>().velocity.y < 0)
		{
			GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (FallSpeed - 1) * Time.deltaTime;
		}
		else if (GetComponent<Rigidbody>().velocity.y > 0 && !Input.GetButton("Jump"))
		{
			GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (JumpHeight - 1) * Time.deltaTime;
		}
	}
}
