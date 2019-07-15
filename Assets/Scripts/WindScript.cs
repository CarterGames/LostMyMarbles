using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
	[Header("Amount of Force")]
	[Tooltip("Amount of force given to objects in the trigger box")]
	public float Force;



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("test");
			other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
		}
	}
}
