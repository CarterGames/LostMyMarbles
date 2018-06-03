using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform Target;
	public Vector3 Anchor;
	public Vector3 MousePos;

	public Vector3 PrevMousePos;



	// Update is called once per frame
	void FixedUpdate ()
	{

		Vector3 NewPos = Target.position;

		NewPos.z -= 2;
		NewPos.y += 3;

		transform.position = NewPos;

		MousePos = Input.mousePosition;




		if (MousePos.x > (PrevMousePos.x + 100))
		{
			Rotate(0, 5, 0);
			RotateUpdate();
			Debug.Log("Right");
			PrevMousePos.x = MousePos.x;
		}
		else if (MousePos.x < (PrevMousePos.x - 100)) 
		{
			Rotate(0, -5, 0);
			RotateUpdate();
			Debug.Log("Left");
			PrevMousePos.x = MousePos.x;
		}

		if (MousePos.y > (PrevMousePos.y + 100))
		{
			Rotate(-5, 0, 0);
			RotateUpdate();
			Debug.Log("Up");
			PrevMousePos.y = MousePos.y;
		}
		if (MousePos.y < (PrevMousePos.y - 100))
		{
			Rotate(5, 0, 0);
			RotateUpdate();
			Debug.Log("Down");
			PrevMousePos.y = MousePos.y;
		}

		Debug.Log("No If Statements Active");
	}



	void Rotate(float x, float y, float z)
	{
		transform.rotation *= Quaternion.Euler(x, y, z);
	}

	void RotateUpdate()
	{
		transform.position += (transform.rotation * Anchor);
	}

}
