using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camcol : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		transform.localPosition = new Vector3(0, 4, -7);
	}
}
