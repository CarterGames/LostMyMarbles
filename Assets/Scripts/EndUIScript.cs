using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndUIScript : MonoBehaviour
{
	public LevelScores ThisLevelData;

	private int Position;
	private SaveScript Save;
	internal int NewScorePosition;
	private List<Text> Elements;

	private void Start()
	{
		Elements = new List<Text>();

		for (int i = 0; i < GetComponentsInChildren<Text>().Length; i++)
		{
			Elements.Add(GetComponentsInChildren<Text>()[i]);
		}
	}

	internal void GetData()
    {
		ThisLevelData = new LevelScores();

		Save = FindObjectOfType<SaveScript>();

		for (int i = 0; i < Save.LevelData.Count; i++)
		{
			if (Save.LevelData[i].LevelName == SceneManager.GetActiveScene().name)
			{
				ThisLevelData = Save.LevelData[i];
				Position = i;
				SetValues();
			}
		}
    }

	private void SetValues()
	{
		Elements[0].text = "Level: " + ThisLevelData.LevelName.Substring(ThisLevelData.LevelName.Length - 1);
		Elements[1].text = "Star Time\n" + ConvertTime(ThisLevelData.StarTime);
		Elements[2].text = "1st: " + ThisLevelData.BestTimeName + "\n" + ConvertTime(ThisLevelData.BestTime);
		Elements[3].text = "2nd: " + ThisLevelData.SecondBestName + "\n" + ConvertTime(ThisLevelData.SecondBestTime);
		Elements[4].text = "3rd: " + ThisLevelData.ThirdBestName + "\n" + ConvertTime(ThisLevelData.ThirdBestTime);
	}


	private string ConvertTime(float Time)
	{
		string Mins = Mathf.FloorToInt(Time / 60).ToString("00");
		string Secs = (Time % 60).ToString("00");
		string MilSecs = ((Time * 100) % 100).ToString("00");
		return Mins + ":" + Secs + ":" + MilSecs;
	}

	public void UpdatePlayerNameText()
	{
		string Name = GetComponentInChildren<InputField>().text;

		switch (NewScorePosition)
		{
			case 1:
				ThisLevelData.BestTimeName = Name;
				Save.LevelData[Position] = ThisLevelData;
				break;
			case 2:
				ThisLevelData.SecondBestName = Name;
				Save.LevelData[Position] = ThisLevelData;
				break;
			case 3:
				ThisLevelData.ThirdBestName = Name;
				Save.LevelData[Position] = ThisLevelData;
				break;
			default:
				break;
		}

		SetValues();
		Save.SaveData();
	}


	public void CloseNameUI()
	{
		GameObject.Find("NewRecordUI").SetActive(false);
	}
}
