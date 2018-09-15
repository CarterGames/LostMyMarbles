using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPadScript : MonoBehaviour
{
	// Marble object so it can be freezed
	[Header("Player Object")]
	public GameObject Marble;
	public GameObject Manager;
	public GameObject MainCamera;

	public TimerScript TimerScript;

	public float FinishTime;

	public bool LevelEnded = false;

	// Rigidbody for the player, just to save a bit of space in the code
	private Rigidbody PlayerRB;
	private GameController ControllerScript;
	private Transform CameraCtrl;

	// Use this for initialization
	void Start ()
	{
		// Sets PlayerRB to the players rigid body component
		PlayerRB = Marble.GetComponent<Rigidbody>();

		CameraCtrl = MainCamera.GetComponent<Transform>();

		ControllerScript = Manager.GetComponent<GameController>();

		TimerScript = GetComponent<TimerScript>();

		TimerScript.SetStartTimer(true);
	}
	


	void Update()
	{

		if (LevelEnded == true)
		{
			ControllerScript.ChangeLevelState(LevelStates.Finished);
		}
		else if (Input.GetButton("Cancel"))                          // If the button mapped cancel is pressed
		{
			ControllerScript.LoadCurrentScene(GameStates.Quit);                  // Quit the appilcation (only works on a built version of the game)
		}






		if ((TimerScript.GetTimer() > 5f) && (LevelEnded == true))
		{
			CameraCtrl.RotateAround(Marble.transform.position, new Vector3(0, 1, 0), 100 * Time.deltaTime);

			TimerScript.SetStartTimer(false);
			TimerScript.SetTimer(0);
			LevelEnded = false;
			ControllerScript.LoadCurrentScene(GameStates.Menu);
		}
	}



	// When the marble collides with the end pad trigger volume
	private void OnTriggerEnter(Collider other)
	{
		LevelEnded = true;											// Used to identify that the level has ended

		PlayerRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;     // Freezes the player

		FinishTime = TimerScript.GetTimer() - 5f;					// Sets the Finish time to the time the level took taking off the loading time
		FinishTime = Mathf.Round(FinishTime * 100.0f) * 0.01f;		// Rounds the Finish time to 2 decimal places
		ControllerScript.SetTmer(FinishTime);						// Sets the time on the controller script to the finish time
		TimerScript.SetTimer(0);									// Resets the Timer in the timescript
		TimerScript.SetStartTimer(true);							// Sets the Timer to run again for the endl level freeze.
	}




	public bool GetLevelEnded()
	{
		return LevelEnded;
	}
}
