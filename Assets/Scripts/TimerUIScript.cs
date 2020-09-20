using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CarterGames.LostMyMarbles
{
	public class TimerUIScript : MonoBehaviour
	{
		internal bool RunTimer;
		private float Timer;
		private Text TimerText;
		private SaveScript Scores;
		private LevelScores Changes;
		private EndUIScript EndUI;
		private EndPadScript EpScript;
		private bool AreGems;
		private GameObject GemUI;

		// Start is called before the first frame update
		void Start()
		{
			Scores = FindObjectOfType<SaveScript>();
			TimerText = GetComponentsInChildren<Text>()[1];
			EndUI = FindObjectOfType<EndUIScript>();
			EpScript = FindObjectOfType<EndPadScript>();
			GemUI = GameObject.Find("GemsUI");
			GemUI.SetActive(false);
			AreGems = GameObject.FindGameObjectWithTag("Gem");
		}

		// Update is called once per frame
		void Update()
		{
			if (RunTimer)
			{
				Timer += Time.deltaTime;
			}

			DisplayTime();

			if (AreGems)
			{
				GemUI.SetActive(true);
				GemUI.GetComponentInChildren<Text>().text = " " + EpScript.GemsCollected + " / " + EpScript.NumberofGems;
			}
		}

		// Converts the float to a int and sets up its display value
		private void DisplayTime()
		{
			string Mins = Mathf.Floor(Timer / 60).ToString("00");
			string Secs = Mathf.Floor(Timer % 60).ToString("00");
			string MilSecs = ((Timer * 100) % 100).ToString("00");

			TimerText.text = Mins + ":" + Secs + ":" + MilSecs;
		}

		// Stop the timer and save the score
		internal void StopTimer()
		{
			RunTimer = false;
			UpdateLevelScores();
		}


		private void UpdateLevelScores()
		{
			int Position = 0;

			for (int i = 0; i < Scores.LevelData.Count; i++)
			{
				if (Scores.LevelData[i].LevelName == SceneManager.GetActiveScene().name)
				{
					Changes = Scores.LevelData[i];
					//Debug.Log("Prev Best Time v1" + " : " + Changes.BestTime);
					Position = i;
				}
				else
				{
					Debug.Log(Scores.LevelData[i].LevelName);
					Debug.Log("Unable to find level data...");
				}
			}

			//Changes.LastTime = Timer;

			//Debug.Log("Prev Best Time" + " : " + Changes.BestTime);

			// Sorting out if the time is a new best or not.........

			//switch (Timer)
			//{
			//	case float number when (number < Changes.BestTime):
			//		Changes.ThirdBestTime = Changes.SecondBestTime;
			//		Changes.ThirdBestName = Changes.SecondBestName;
			//		Changes.SecondBestTime = Changes.BestTime;
			//		Changes.SecondBestName = Changes.BestTimeName;
			//		Changes.BestTime = Timer;
			//		EndUI.NewScorePosition = 1;
			//		Changes.BestTimeName = "New Best Score!!!";
			//		Debug.Log("Best Time");
			//		break;
			//	case float number when (number < Changes.SecondBestTime):
			//		//Changes.ThirdBestTime = Changes.SecondBestTime;
			//		//Changes.ThirdBestName = Changes.SecondBestName;
			//		//Changes.SecondBestTime = Timer;
			//		//EndUI.NewScorePosition = 2;
			//		//Changes.SecondBestName = "New 2nd Best Score!!!";
			//		//Debug.Log("Second Best Time");
			//		break;
			//	case float number when (number < Changes.ThirdBestTime):
			//		Changes.ThirdBestTime = Timer;
			//		EndUI.NewScorePosition = 3;
			//		Changes.ThirdBestName = "New 3rd Best Score!!!";
			//		Debug.Log("Third Best Time");
			//		break;
			//	default:
			//		EndUI.CloseNameUI();
			//		break;
			//}


			// Sets the new changes, in theory
			Scores.LevelData[Position] = Changes;

			Scores.SaveData();
		}
	}
}