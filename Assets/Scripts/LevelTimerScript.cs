using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimerScript : MonoBehaviour
{
	internal string PlayerName;
	internal bool RunTimer;
	private float Timer;
	private Text TimerText;
	private SaveScript Scores;

	// Start is called before the first frame update
	void Start()
    {
		Scores = FindObjectOfType<SaveScript>();
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
		UpdateLevelScores();
	}

	internal float GetTmer()
	{
		return Timer;
	}


	private void UpdateLevelScores()
	{
		LevelScores Changes = new LevelScores();
		int Position = 0;

		for (int i = 0; i < Scores.PerLevelData.Count; i++)
		{
			if (Scores.PerLevelData[i].LevelName == SceneManager.GetActiveScene().name)
			{
				Changes = Scores.PerLevelData[i];
				Position = i;
				Debug.Log(Scores.PerLevelData[i].BestTime);
				Debug.Log(i);
			}
		}

		Changes.LastTime = Timer;

		Debug.Log(Changes.LastTime);
		Debug.Log(Changes.BestTime + " --- Best Time");
		// Sorting out if the time is a new best or not.........

		if (Timer < Changes.BestTime)
		{
			Changes.ThirdBestTime = Changes.SecondBestTime;
			Changes.ThirdBestName = Changes.SecondBestName;
			Changes.SecondBestTime = Changes.BestTime;
			Changes.SecondBestName = Changes.BestTimeName;
			Changes.BestTime = Timer;
			Changes.BestTimeName = PlayerName;
			Debug.Log("Best Time");
		}
		else if (Timer < Changes.SecondBestTime)
		{
			Changes.ThirdBestTime = Changes.SecondBestTime;
			Changes.ThirdBestName = Changes.SecondBestName;
			Changes.SecondBestTime = Timer;
			Changes.SecondBestName = PlayerName;
			Debug.Log("Second Best Time");
		}
		else if (Timer < Changes.ThirdBestTime)
		{
			Changes.ThirdBestTime = Timer;
			Changes.ThirdBestName = PlayerName;
			Debug.Log("Third Best Time");
		}


		// Sets the new changes, in theory
		Scores.PerLevelData[Position] = Changes;

		Scores.SaveData();
	}
}
