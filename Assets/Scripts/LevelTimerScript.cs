using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerScript : MonoBehaviour
{
	internal bool RunTimer;
	private float Timer;
	private Text TimerText;

	// Start is called before the first frame update
	void Start()
    {
		TimerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RunTimer)
		{
			Timer += Time.deltaTime;
		}

		DisplayTime();
    }

	// Converts the float to a int and sets up its display value
	private void DisplayTime()
	{ 
		string Mins = Mathf.FloorToInt(Timer / 60).ToString("00");
		string Secs = (Timer % 60).ToString("00");
		string MilSecs = ((Timer * 100) % 100).ToString("00");

		TimerText.text = Mins + ":" + Secs + ":" + MilSecs;
	}

	// Stop the timer and save the score
	internal void StopTimer()
	{
		RunTimer = false;
	}
}
