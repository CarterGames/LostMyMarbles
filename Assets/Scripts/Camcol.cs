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

	private void Update()
	{
		transform.localPosition = new Vector3(0, Marble.transform.position.y - 2, -7);
	}

	private void OnCollisionEnter(Collision collision)
	{
		//transform.localPosition = new Vector3(0, Marble.transform.position.y + 4, -7);
	}
}
