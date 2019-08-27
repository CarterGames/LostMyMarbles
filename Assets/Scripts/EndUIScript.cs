using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndUIScript : MonoBehaviour
{
	public LevelScores ThisLevelData;	// A LevelScores to hold the new data for this level

	private int Position;				// Int to hold the position in the save data this level is in
	private SaveScript Save;			// Ref to the save script
	internal int NewScorePosition;		// Int to hold the position the player got on the attempt
	private List<Text> Elements;        // List to hold the text compoents

	private bool IsCoRunning;

	// Start
	private void Start()
	{
		// Init List of Text components
		Elements = new List<Text>();

		for (int i = 0; i < GetComponentsInChildren<Text>().Length; i++)
		{
			Elements.Add(GetComponentsInChildren<Text>()[i]);
		}
	}


	// Gets the latest data from the save file to be inputted into the end UI
	internal void GetData()
    {
		// Sets up a new levelscores to hold the loaded data
		ThisLevelData = new LevelScores();

		// Refers to the save script wherever it is in the scene
		Save = FindObjectOfType<SaveScript>();

		// for each level scores in the save 
		for (int i = 0; i < Save.LevelData.Count; i++)
		{
			// Find the level scores relevant to this level
			if (Save.LevelData[i].LevelName == SceneManager.GetActiveScene().name)
			{
				// Set the levelscores varible to the leveldata needed
				ThisLevelData = Save.LevelData[i];

				// Sets the position needed when saving again
				Position = i;

				// runs the setvalues function
				SetValues();
			}
		}
    }

	private void SetValues()
	{
		//Elements[0].text = "Level: " + ThisLevelData.LevelName.Substring(ThisLevelData.LevelName.Length - 1);
		//Elements[2].text = "1st: " + ThisLevelData.BestTimeName + "\n" + ConvertTime(ThisLevelData.BestTime);
		//Elements[3].text = "2nd: " + ThisLevelData.SecondBestName + "\n" + ConvertTime(ThisLevelData.SecondBestTime);
		//Elements[4].text = "3rd: " + ThisLevelData.ThirdBestName + "\n" + ConvertTime(ThisLevelData.ThirdBestTime);
	}


	private string ConvertTime(float Time)
	{
		if (Time == 9999999) { return "99:99:99"; }
		else
		{
			string Mins = Mathf.FloorToInt(Time / 60).ToString("00");
			string Secs = Mathf.Floor((Time % 60)).ToString("00");
			string MilSecs = ((Time * 100) % 100).ToString("00");
			return Mins + ":" + Secs + ":" + MilSecs;
		}
	}

	public void UpdatePlayerNameText()
	{
		string Name = GetComponentInChildren<InputField>().text;

		switch (NewScorePosition)
		{
			case 1:
				//ThisLevelData.BestTimeName = Name;
				Save.LevelData[Position] = ThisLevelData;
				break;
			case 2:
				//ThisLevelData.SecondBestName = Name;
				Save.LevelData[Position] = ThisLevelData;
				break;
			case 3:
				//ThisLevelData.ThirdBestName = Name;
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


	// Takes the player to the next level
	public void NextLevel()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
	}


	public void Menu()
	{
		SceneManager.LoadSceneAsync("Menu");
	}


	public void Replay()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}

	public void ClearInputFeild()
	{
		GetComponentInChildren<InputField>().text = "";
	}

	//private IEnumerator ChangeScene()
	//{
	//	IsCoRunning = true;
	//	GetComponentInChildren<Animator>().SetBool("LevelChange", true);
	//	yield return new WaitForSeconds(1);
	//	SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

	//}
}
