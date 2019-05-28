using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotate : MonoBehaviour
{
	public float MoveSpd;

	private void Update()
	{
		transform.Rotate(new Vector3(0, MoveSpd, 0));
	}
}
