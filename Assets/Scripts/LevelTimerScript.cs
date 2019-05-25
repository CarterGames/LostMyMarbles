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
	private LevelScores Changes;
	private EndUIScript EndUI;

	// Start is called before the first frame update
	void Start()
    {
		Scores = FindObjectOfType<SaveScript>();
		TimerText = GetComponentInChildren<Text>();
		EndUI = FindObjectOfType<EndUIScript>();
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
		int Position = 0;

		for (int i = 0; i < Scores.LevelData.Count; i++)
		{
			if (Scores.LevelData[i].LevelName == SceneManager.GetActiveScene().name)
			{
				Changes = Scores.LevelData[i];
				Debug.Log("Prev Best Time v1" + " : " + Changes.BestTime);
				Position = i;
			}
			else
			{
				Debug.Log(Scores.LevelData[i].LevelName);
				Debug.Log("Unable to find level data...");
			}
		}

		Changes.LastTime = Timer;

		Debug.Log("Prev Best Time" + " : " + Changes.BestTime);

		// Sorting out if the time is a new best or not.........

		if (Timer < Changes.BestTime)
		{
			Changes.ThirdBestTime = Changes.SecondBestTime;
			Changes.ThirdBestName = Changes.SecondBestName;
			Changes.SecondBestTime = Changes.BestTime;
			Changes.SecondBestName = Changes.BestTimeName;
			Changes.BestTime = Timer;
			Changes.BestTimeName = PlayerName;
			EndUI.NewScorePosition = 1;
			Debug.Log("Best Time");
		}
		else if (Timer < Changes.SecondBestTime)
		{
			Changes.ThirdBestTime = Changes.SecondBestTime;
			Changes.ThirdBestName = Changes.SecondBestName;
			Changes.SecondBestTime = Timer;
			Changes.SecondBestName = PlayerName;
			EndUI.NewScorePosition = 2;
			Debug.Log("Second Best Time");
		}
		else if (Timer < Changes.ThirdBestTime)
		{
			Changes.ThirdBestTime = Timer;
			Changes.ThirdBestName = PlayerName;
			EndUI.NewScorePosition = 3;
			Debug.Log("Third Best Time");
		}
		else
		{
			EndUI.CloseNameUI();
		}


		// Sets the new changes, in theory
		Scores.LevelData[Position] = Changes;

		Scores.SaveData();
	}
}
