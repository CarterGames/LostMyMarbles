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

	[Tooltip("Amount the rotationg happens")]
	public float RotationAmount;

	private Vector3 StartRot;


	private void Start()
	{
		StartRot = new Vector3(FanTop.transform.rotation.x, FanTop.transform.rotation.y, FanTop.transform.rotation.z);
	}

	private void Update()
	{
		if (RotateFanTop && (StartRot.y > RotationAmount))
		{
			FanTop.transform.Rotate(-RotationAmount, 0, 0);
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
