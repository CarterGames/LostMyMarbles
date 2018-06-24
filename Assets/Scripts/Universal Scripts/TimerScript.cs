using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//	Universal Timer Script, with getters and setters
//

public class TimerScript : MonoBehaviour
{

	[Header("Timer Variables")]
	public float Timer;			// Timer float
	public bool StartTimer;		// Bool to start or stop the timer

	
	// Update is called once per frame
	void Update ()
	{
		// If the Start Timer Bool is true, then
		if (StartTimer == true)
		{
			// Start counting up, by 1
			Timer += 1 * Time.deltaTime;
		}
		else
		{
			// DO Nothing
		}
	}



	//
	//
	//			Getter's 
	//
	//

	
	// Get the Timer Float
	public float GetTimer()
	{
		return Timer;
	}

	// Get the Start Timer Bool
	public bool GetStartTimer()
	{
		return StartTimer;
	}



	//
	//
	//			Setter's
	//
	//



	// Sets the Timer float to the input
	public void SetTimer(float input)
	{
		Timer = input;
		return;
	}

	// Sets the StartTimer bool to the input
	public void SetStartTimer(bool input)
	{
		StartTimer = input;
		return;
	}
}
