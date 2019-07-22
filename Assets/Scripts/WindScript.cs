using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
	[Header("Amount of Force")]
	[Tooltip("Amount of force given to objects in the trigger box")]
	public float Force;


	[Header("Fan Rotation Controls")]
	[Tooltip("The Fan Top Area Object")]
	public GameObject FanTop;

	[Tooltip("Should the fan top rotate?")]
	public bool RotateFanTop;

	[Tooltip("Speed of Fan Rotation")]
	public float RotationSpeed;

	private bool Dir;



	private void Update()
	{
		if (RotateFanTop)
		{
			switch (Mathf.FloorToInt(FanTop.transform.localRotation.eulerAngles.y))
			{
				case 20:
					Dir = false;
					break;
				case 340:
					Dir = true;
					break;
				default:
					break;
			}


			if (Dir)
			{
				FanTop.transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
			}
			else if (!Dir)
			{
				FanTop.transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
			}
		}
	}


	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("test");
			other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Force, ForceMode.Acceleration);
		}
	}
}