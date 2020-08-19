using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using CarterGames.Assets.AudioManager;


public class LevelSelectScript : MonoBehaviour
{

    public LevelScores TopLeft;
    public LevelScores TopRight;
    public LevelScores BottomLeft;
    public LevelScores BottomRight;

	public List<LevelScores> AllLevels;
	public List<Sprite> LevelImages;

	public Text LevelNameText;
	public Text PBText;
	public Text LastText;
	public Image LevelPreviewImage;

	public Button LeftButton;
	public Button RightButton;

	private int LastPos;
	private SaveScript Save;

	private AudioManager Audio;

    private int Slide = 1;
    private int MaxSlides = 2;

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
		UpdateUI();
	}

    private void Update()
    {
        if (AllLevels.Count == 0)
        {
            AllLevels = Save.LevelData;
            GetLevelScores();
        }
    }

    // Updates the UI elements on th elevel select
    private void UpdateUI()
	{
		//LevelNameText.text = "Level: " + GetLevelNumber(CurrentLevelSelected.LevelName);
		//PBText.text = "PB: " + CurrentLevelSelected.BestTimeName + "\n" + ConvertTime(CurrentLevelSelected.BestTime);
		//LastText.text = "Last: " + CurrentLevelSelected.SecondBestName + "\n" + ConvertTime(CurrentLevelSelected.SecondBestTime);
		//LevelPreviewImage.sprite = LevelImages[int.Parse(GetLevelNumber(CurrentLevelSelected.LevelName)) - 1];
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
        if (Slide == 1)
        {
            Slide = MaxSlides;
            // Change Levels Shown
            GetLevelScores();
        }
        else
        {
            Slide--;
            // Change Levels Shown
            GetLevelScores();
        }

        //if (LastPos - 1 >= 0) { LastPos--; CurrentLevelSelected = AllLevels[LastPos]; }
		//else { LastPos = AllLevels.Count - 1; CurrentLevelSelected = AllLevels[LastPos]; }
		UpdateUI();
		Audio.Play("Button_Press", 1f ,.65f);
	}


	public void RightPressed()
	{
        if (Slide == MaxSlides)
        {
            Slide = 1;
            // Change Levels Shown
            GetLevelScores();
        }
        else
        {
            Slide++;
            // Change Levels Shown
            GetLevelScores();
        }

        //if (LastPos + 1 != AllLevels.Count) { LastPos++; CurrentLevelSelected = AllLevels[LastPos]; }
		//else { LastPos = 0; CurrentLevelSelected = AllLevels[LastPos]; }
		UpdateUI();
		Audio.Play("Button_Press", 1f, .75f);
	}



	public void PlayLevel()
	{
		//SceneManager.LoadSceneAsync(CurrentLevelSelected.LevelName);
		Audio.Play("Button_Press");
	}


    public void GetLevelScores()
    {
        BottomRight = AllLevels[(Slide * 4) - 1];
        BottomLeft = AllLevels[(Slide * 4) - 2];
        TopRight = AllLevels[(Slide * 4) - 3];
        TopLeft = AllLevels[(Slide * 4) - 4];
    }
}