using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using CarterGames.Assets.AudioManager;

public class SettingsScript : MonoBehaviour
{

	public QualitySettings Quality;

	private bool IsFullScreen = false;

	public Dropdown QualityDD;

	public Dropdown ResOptions;
	public Resolution[] AllResOptions;
	public int CurrentResIndex = 0;
	public List<string> Options;


	public GameObject Video;
	public GameObject Audio;
	public GameObject Marbles;

	private AudioManager AudioManager;

	private void Start()
	{
		AudioManager = FindObjectOfType<AudioManager>();

		AllResOptions = Screen.resolutions.Distinct().ToArray();

		ResOptions.ClearOptions();

		Options = new List<string>();

		for (int i = 0; i < AllResOptions.Length; i++)
		{
			Options.Add(AllResOptions[i].width + " x " + AllResOptions[i].height + " @ " + AllResOptions[i].refreshRate + "Hz");

			if (CheckRes(AllResOptions[i], Screen.currentResolution))
			{
				CurrentResIndex = i;
			}
		}

		Options.Add("");
		ResOptions.AddOptions(Options);
		ResOptions.value = CurrentResIndex;
		ResOptions.RefreshShownValue();
	}


	public void SetAASetting(int Input)
	{
		if (Input.ToString() != "Disabled")
		{
			QualitySettings.SetQualityLevel(5);
			QualityDD.RefreshShownValue();
			QualitySettings.antiAliasing = Input;
		}
	}


	public void SetRes(int ResIndex)
	{
		Screen.SetResolution(AllResOptions[ResIndex].width, AllResOptions[ResIndex].height, IsFullScreen);
		//AudioManager.PlayClip("Button_Press", Pitch: .5f);
	}


	public void SetFullScreen(bool Input)
	{
		Screen.fullScreen = Input;
		AudioManager.Play("Button_Press", 1f, .5f);
	}


	public void SetQuailty(int Input)
	{
		QualitySettings.SetQualityLevel(Input);
		AudioManager.Play("Button_Press", 1f, .5f);
	}


	private bool CheckRes(Resolution Current, Resolution TestRes)
	{
		if ((Current.width == TestRes.width) && (Current.height == TestRes.height)) { return true; }
		else { return false; }
	}
}
