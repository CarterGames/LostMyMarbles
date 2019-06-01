using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class LevelSelectScript : MonoBehaviour
{

	public LevelScores CurrentLevelSelected;
	public List<LevelScores> AllLevels;

	public Text LevelNameText;
	public Text GoldTimeText;
	public Text SilverTimeText;
	public Text BronzeTimeText;
	public Image LevelPreviewImage;

	public Button LeftButton;
	public Button RightButton;

	private int LastPos;
	private SaveScript Save;

	private void Awake()
	{
		Save = FindObjectOfType<SaveScript>();
	}

	private void Start()
	{
		Save.LoadData();
		AllLevels = Save.LevelData;
		CurrentLevelSelected = AllLevels[0];
		UpdateUI();
	}

	// Updates the UI elements on th elevel select
	private void UpdateUI()
	{
		LevelNameText.text = "Level: " + GetLevelNumber(CurrentLevelSelected.LevelName);
		GoldTimeText.text = "1st: " + CurrentLevelSelected.BestTimeName + "\n" + ConvertTime(CurrentLevelSelected.BestTime);
		SilverTimeText.text = "2nd: " + CurrentLevelSelected.SecondBestName + "\n" + ConvertTime(CurrentLevelSelected.SecondBestTime);
		BronzeTimeText.text = "3rd: " + CurrentLevelSelected.ThirdBestName + "\n" + ConvertTime(CurrentLevelSelected.ThirdBestTime);
	}

	// Converts the Timer float value to a more readable format
	private string ConvertTime(float Time)
	{
		if (Time == 9999999) { return "99:99:99"; }
		else {
			string Mins = Mathf.FloorToInt(Time / 60).ToString("00");
			string Secs = Mathf.Floor((Time % 60)).ToString("00");
			string MilSecs = ((Time * 100) % 100).ToString("00");
			return Mins + ":" + Secs + ":" + MilSecs;
		}
	}

	// Returns the value of the level number in the correct format as an string containing an int
	//	If the number is 2 digit it substrings to lenght - 2
	//	Otherwise it returns the lenght - 1
	private string GetLevelNumber(string Input)
	{
		if (Input.Substring(Input.Length - 2) == "l" + Input.Substring(Input.Length - 1)) { return Input.Substring(Input.Length - 1); }
		else { return Input.Substring(Input.Length - 2); }
	}



	public void LeftPressed()
	{
		if (LastPos - 1 >= 0) { LastPos--; CurrentLevelSelected = AllLevels[LastPos]; }
		else { LastPos = AllLevels.Count - 1; CurrentLevelSelected = AllLevels[LastPos]; }
		UpdateUI();
	}

	public void RightPressed()
	{
		if (LastPos + 1 != AllLevels.Count) { LastPos++; CurrentLevelSelected = AllLevels[LastPos]; }
		else { LastPos = 0; CurrentLevelSelected = AllLevels[LastPos]; }
		UpdateUI();
	}
}