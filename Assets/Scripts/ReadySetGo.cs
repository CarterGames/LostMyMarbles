using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadySetGo : MonoBehaviour
{

	[Header("Colours, NOTE: make sure the ALPHA is 1")]
	public Color Text1Colour;		// Colour 1, User Defined
	public Color Text2Colour;       // Colour 2, User Defined
	public Color Text3Colour;       // Colour 3, User Defined

	[Header("Text UI Element to Draw to")]
	public Text DisplayText;        // Text UI Element that the text is on

	[Header("Player")]
	public GameObject Player;

	// Timer Variables, The timer is fixed so there is no need for a header
	private float Timer;			// Float for the Timer
	private int TimerConvert;       // Int for the conversion so the float can be used in the switch statement

	// Rigidbody for the player, just to save a bit of space in the code
	private Rigidbody PlayerRB;

	// Timer Reference
	private TimerUIScript TimeCtrl;

	private void Start()
	{
		// Sets PlayerRB to the players rigid body component
		PlayerRB = Player.GetComponent<Rigidbody>();

		// Timer Reference
		TimeCtrl = FindObjectOfType<TimerUIScript>();
	}

	// Update is called once per frame
	void Update()
	{

		// If statement to stop the timer and switch statement from running overtime
		if (Timer < 7)
		{
			// Adds 1 to the timer every game frame
			Timer += 1 * Time.deltaTime;

			// Converts the Timer float to an int for the next part
			TimerConvert = Mathf.FloorToInt(Timer);

			// Switch Case as its neater than if else in this case
			switch (TimerConvert)
			{
				// Case 0 - No Text
				case (0):
					DisplayText.text = " ";
					PlayerRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;     // Freezes the player, but they can still jump
					break;

				// Case 1 - READY Text, Colour 1
				case (1):
					DisplayText.color = Text1Colour;
					DisplayText.text = "READY";
					break;

				// Case 3 - SET Text, Colour 2
				case (3):
					DisplayText.color = Text2Colour;
					DisplayText.text = "SET";
					break;

				// Case 5 - GO Text, Colour 3
				case (5):
					DisplayText.color = Text3Colour;
					DisplayText.text = "GO!";
					TimeCtrl.RunTimer = true;
					PlayerRB.constraints = RigidbodyConstraints.None;   // Allows the player to move again
					break;

				// Case 6 - No Text
				case (6):
					DisplayText.text = " ";

					foreach (ZomballScript i in FindObjectsOfType<ZomballScript>())
					{
						i.Enabled = true;
					}

					break;
			}
		}
	}
}
