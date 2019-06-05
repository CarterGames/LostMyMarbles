using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class LevelSelectScript : MonoBehaviour
{

	public LevelScores CurrentLevelSelected;
	public List<LevelScores> AllLevels;
	public List<Sprite> LevelImages;

	public Text LevelNameText;
	public Text CrystalTimeText;
	public Text GoldTimeText;
	public Text SilverTimeText;
	public Text BronzeTimeText;
	public Image LevelPreviewImage;

	public Button LeftButton;
	public Button RightButton;

	private int LastPos;
	private SaveScript Save;

	private Color32 CrystalCol = new Color32(25, 150, 150, 255);

	private AudioManager Audio;

	private void Awake()
	{
		Save = FindObjectOfType<SaveScript>();

		Debug.Log(Resources.LoadAll("LevelScreenshots", typeof(Sprite)).Cast<Sprite>().ToList().Count);

		for (int i = 0; i < Resources.LoadAll("LevelScreenshots", typeof(Sprite)).Cast<Sprite>().ToList().Count; i++)
		{
			LevelImages.Add(Resources.LoadAll("LevelScreenshots", typeof(Sprite)).Cast<Sprite>().ToList()[i]);
		}
	}

	private void Start()
	{
		Audio = FindObjectOfType<AudioManager>();
		Save.LoadData();
		AllLevels = Save.LevelData;
		CurrentLevelSelected = AllLevels[0];
		UpdateUI();
	}

	// Updates the UI elements on th elevel select
	private void UpdateUI()
	{
		LevelNameText.text = "Level: " + GetLevelNumber(CurrentLevelSelected.LevelName);
		CrystalTimeText.text = "Crystal Time" + "\n" + ConvertTime(CurrentLevelSelected.CrystalTime);
		GoldTimeText.text = "1st: " + CurrentLevelSelected.BestTimeName + "\n" + ConvertTime(CurrentLevelSelected.BestTime);
		SilverTimeText.text = "2nd: " + CurrentLevelSelected.SecondBestName + "\n" + ConvertTime(CurrentLevelSelected.SecondBestTime);
		BronzeTimeText.text = "3rd: " + CurrentLevelSelected.ThirdBestName + "\n" + ConvertTime(CurrentLevelSelected.ThirdBestTime);
		LevelPreviewImage.sprite = LevelImages[int.Parse(GetLevelNumber(CurrentLevelSelected.LevelName)) - 1];
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


	private void IsCrystalTime(float Crystal, float Input)
	{
		if (Input < Crystal)
		{

		}
	}


	public void LeftPressed()
	{
		Audio.PlayClip("Button_Pressed", Pitch: .75f);
		if (LastPos - 1 >= 0) { LastPos--; CurrentLevelSelected = AllLevels[LastPos]; }
		else { LastPos = AllLevels.Count - 1; CurrentLevelSelected = AllLevels[LastPos]; }
		UpdateUI();
	}


	public void RightPressed()
	{
		Audio.PlayClip("Button_Pressed", Pitch: .85f);
		if (LastPos + 1 != AllLevels.Count) { LastPos++; CurrentLevelSelected = AllLevels[LastPos]; }
		else { LastPos = 0; CurrentLevelSelected = AllLevels[LastPos]; }
		UpdateUI();
	}


	public void PlayLevel()
	{
		SceneManager.LoadSceneAsync(CurrentLevelSelected.LevelName);
		Audio.PlayClip("Button_Pressed");
	}
}