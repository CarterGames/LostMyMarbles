using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public GameObject Target;

	private Vector3 Offset;


    void LateUpdate()
    {
		transform.LookAt(Target.transform);
    }
}
