using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomballScript : MonoBehaviour
{
	public GameObject Target;
	public float ZomballSpd;
	public bool Enabled;
	public NavMeshAgent Agent;

    void Update()
    {
		if (Enabled)
		{
			Agent.SetDestination(Target.transform.position);
		}
	}
}
