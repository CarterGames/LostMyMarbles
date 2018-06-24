using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPadScript : MonoBehaviour
{
	// Marble object so it can be freezed
	[Header("Player Object")]
	public GameObject Marble;

	public TimerScript TimeScript;

	// Rigidbody for the player, just to save a bit of space in the code
	private Rigidbody PlayerRB;

	// Use this for initialization
	void Start ()
	{
		// Sets PlayerRB to the players rigid body component
		PlayerRB = Marble.GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (TimeScript.GetTimer() > 1.5f)
		{
			// Do End Stuff
			Debug.Log("End");
		}
	}

	// When the marble collides with the end pad trigger volume
	private void OnTriggerEnter(Collider other)
	{
		TimeScript.SetTimer(0);
		TimeScript.SetStartTimer(true);

		PlayerRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;     // Freezes the player
	}
}
