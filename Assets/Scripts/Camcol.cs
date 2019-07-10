using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcol : MonoBehaviour
{
	private GameObject Marble;

	private void Start()
	{
		Marble = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnCollisionEnter(Collision collision)
	{
		transform.localPosition = new Vector3(0, Marble.transform.position.y + 4, -7);
	}
}
