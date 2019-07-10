using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPadScript : MonoBehaviour
{
	public GameObject Marble;		// The Marble GameObject
	public float RotSpd;			// The ROtation Speed of the end pad camera spin

	private bool IsRot;					// Is the marble rotating?
	private bool IsCoRunning;			// Is the courutine running? - just stops it been called a million times
	private Canvas EndUIElements;		// The Canvas that holds the end of level UI
	private CameraController CamCtrl;	// The Camera Controller Script
	private TimerUIScript UICtrl;	// The Level Timer Script

	/* Gem Variables */
	internal int GemsCollected;     // Number of Gems Collected
	internal int NumberofGems;        // Number of gems in the level
	public bool AreGemsInLevel;		// Checks to see if gems are in the level

	
    private void Start()
    {
		// Setting up references
		CamCtrl = Camera.main.GetComponentInParent<CameraController>();
		UICtrl = FindObjectOfType<TimerUIScript>();
		EndUIElements = GetComponentInChildren<Canvas>();

		// Disables the end of level ui when referneced
		EndUIElements.enabled = false;

		// Finds any gems in the level and adds them to the list
		if (GameObject.FindGameObjectWithTag("Gem"))
		{
			AreGemsInLevel = true;
			NumberofGems = GameObject.FindGameObjectsWithTag("Gem").Length;
		}
    }


    private void Update()
    {
        if (IsRot)
		{
			// Rotates the camera around the Marble
			Camera.main.transform.parent.transform.parent.eulerAngles += new Vector3(0, RotSpd, 0);
		}
    }


	private void OnTriggerEnter(Collider collision)
	{
		if ((collision.gameObject.tag == "Player") && AreAllGemsCollected())
		{
			// Disables any Zomballs that are in the level if they are present
			if (FindObjectOfType<ZomballScript>())
			{
				for (int i = 0; i < FindObjectsOfType<ZomballScript>().Length; i++)
				{
					FindObjectsOfType<ZomballScript>()[i].enabled = false;
				}
			}

			// Pauses the timer
			UICtrl.StopTimer();

			// Freezes the Camera
			CamCtrl.CamEnabled = false;

			// Freezes the Marbles Position
			Marble.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

			// Enable rotation of the camera
			IsRot = true;

			// Enable Particles
			GetComponentInChildren<ParticleSystem>().Play();

			// Calls the End of level UI
			if (!IsCoRunning)
			{
				StartCoroutine(EndUI());
			}
		}
		else if ((collision.gameObject.tag == "Player") && !AreAllGemsCollected())
		{
			// Don't allow the player to finish the level
		}
	}

	// Corutine that enables the UI when the level has been completed after 2 seconds
	private IEnumerator EndUI()
	{
		IsCoRunning = true;	// stops the corutine from running more than once
		yield return new WaitForSeconds(2);	// pauses for 2 seconds
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HideMouse();	// Toggles the mouse
		EndUIElements.GetComponentInChildren<EndUIScript>().GetData();	// Gets the latest values for this level
		EndUIElements.GetComponent<Canvas>().enabled = true;	// enables the canvas for the end of level ui
	}

	// Checks to see if the player has collected all the gems in the level or not
	private bool AreAllGemsCollected()
	{
		if (AreGemsInLevel)
		{
			if (GemsCollected == NumberofGems) { return true; }
			else { return false; }
		}
		else { return true; }
	}
}
