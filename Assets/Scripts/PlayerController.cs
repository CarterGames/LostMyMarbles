using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	public float MoveSpeed;

	[Range(0,50)]
	public float JumpHeight;
	public float FallSpeed;



	private void Start()
	{
			
	}


	private void Update()
	{
		GetComponent<Rigidbody>().velocity += new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, 0, Input.GetAxis("Vertical") * MoveSpeed);

		JumpSmoothing();

		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Jump Pressed");
			GetComponent<Rigidbody>().velocity = Vector3.up * JumpHeight;
		}
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
