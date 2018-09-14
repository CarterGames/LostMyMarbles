using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPadScript : MonoBehaviour
{
	// Marble object so it can be freezed
	[Header("Player Object")]
	public GameObject Marble;
	public GameObject Manager;

	public TimerScript TimerScript;

	public float FinishTime;

	private bool LevelEnded = false;

	// Rigidbody for the player, just to save a bit of space in the code
	private Rigidbody PlayerRB;
	private GameController ControllerScript;

	// Use this for initialization
	void Start ()
	{
		// Sets PlayerRB to the players rigid body component
		PlayerRB = Marble.GetComponent<Rigidbody>();

		ControllerScript = Manager.GetComponent<GameController>();

		TimerScript = GetComponent<TimerScript>();

		TimerScript.SetStartTimer(true);
	}
	


	void Update()
	{
		if ((TimerScript.GetTimer() > 5f) && (LevelEnded == false))
		{
			ControllerScript.ChangeLevelState(LevelStates.Started);
			TimerScript.SetStartTimer(false);
		}
		else if (LevelEnded == true)
		{
			ControllerScript.ChangeLevelState(LevelStates.Finished);
		}
		else
		{
			ControllerScript.ChangeLevelState(LevelStates.Loading);
		}

		if (Input.GetButton("Cancel"))                          // If the button mapped cancel is pressed
		{
			ControllerScript.LoadCurrentScene(GameStates.Quit);                  // Quit the appilcation (only works on a built version of the game)
		}
	}



	// When the marble collides with the end pad trigger volume
	private void OnTriggerEnter(Collider other)
	{
		LevelEnded = true;

		PlayerRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;     // Freezes the player
	}
}
