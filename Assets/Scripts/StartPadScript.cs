using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPadScript : MonoBehaviour
{

	public GameObject Marble;
	public Vector3 StartPos;

	// Use this for initialization
	void Start ()
	{
		StartPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

		Marble.transform.SetPositionAndRotation(StartPos, Quaternion.Euler(0, 0, 0));
	}
}
