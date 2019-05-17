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

	[Range(0, 15)]
	public float SpeedFalloff = 15;
	public float SpeedReductionRate;
	public float FallOffDelay;

	private Vector3 StartPos;

	private bool IsFalloffRunning;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Jump Pressed");
			GetComponent<Rigidbody>().velocity += Vector3.up * JumpHeight;
		}


		Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		Movement = Camera.main.transform.TransformDirection(Movement);

		GetComponent<Rigidbody>().AddForce(Movement * SpeedFalloff);

		JumpSmoothing();

		if ((Input.anyKey) && (!IsFalloffRunning))
		{
			StartCoroutine(Falloff());
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


	private IEnumerator Falloff()
	{
		if (!IsFalloffRunning)
		{
			IsFalloffRunning = true;

			if (SpeedFalloff > 0)
			{
				SpeedFalloff += SpeedReductionRate;
			}

			yield return new WaitForSeconds(FallOffDelay);
			IsFalloffRunning = false;
		}
	}
}
