using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomballScript : MonoBehaviour
{
	public GameObject Target;
	public float ZomballSpd;


    void Update()
    {
		if (Vector3.Distance(transform.position, Target.transform.position) > 2)
		{
			Vector3 Direction = Target.transform.position - transform.position;
			GetComponent<Rigidbody>().velocity += Direction * ZomballSpd * Time.deltaTime;
		}
	}
}
