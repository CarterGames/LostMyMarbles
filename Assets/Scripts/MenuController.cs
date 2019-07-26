using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Canvas TitleScreen;
	public Canvas LevelSelect;
	public Canvas SettingsScreen;
	public Canvas CreditsScreen;

	public GameObject VideoSet;
	public GameObject AudioSet;
	public GameObject MarbleSet;

	public List<GameObject> SettingsButtons;

	private AudioManager Audio;

	private void Start()
	{
		Audio = FindObjectOfType<AudioManager>();
		TitleScreen.enabled = true;
		LevelSelect.enabled = false;
		CreditsScreen.enabled = false;
		SettingsScreen.enabled = false;
	}


	public void Play()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = true;
		SettingsScreen.enabled = false;
		CreditsScreen.enabled = false;
		Audio.PlayClip("Button_Press");
	}

	public void Settings()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = true;
		CreditsScreen.enabled = false;
		Audio.PlayClip("Button_Press");
	}

	public void Menu()
	{
		TitleScreen.enabled = true;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = false;
		CreditsScreen.enabled = false;
		Audio.PlayClip("Button_Press");
	}


	public void Credits()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = false;
		CreditsScreen.enabled = true;
		Audio.PlayClip("Button_Press");
	}


	public void VideoSettings()
	{
		Debug.Log("Video Settings Button");

		if (AudioSet.activeInHierarchy)
		{
			AudioSet.SetActive(false);
		}

		if (MarbleSet.activeInHierarchy)
		{
			MarbleSet.SetActive(false);
		}

		VideoSet.SetActive(true);

		for (int i = 0; i < SettingsButtons.Count; i++)
		{
			SettingsButtons[i].SetActive(false);
		}

		Audio.PlayClip("Button_Press");
	}


	public void AudioSettings()
	{
		Debug.Log("Audio Settings Button");

		if (VideoSet.activeInHierarchy)
		{
			VideoSet.SetActive(false);
		}

		if (MarbleSet.activeInHierarchy)
		{
			MarbleSet.SetActive(false);
		}

		AudioSet.SetActive(true);

		for (int i = 0; i < SettingsButtons.Count; i++)
		{
			SettingsButtons[i].SetActive(false);
		}

		Audio.PlayClip("Button_Press");
	}


	public void MarbleSettings()
	{
		Debug.Log("Marble Settings Button");

		if (VideoSet.activeInHierarchy)
		{
			VideoSet.SetActive(false);
		}

		if (AudioSet.activeInHierarchy)
		{
			AudioSet.SetActive(false);
		}

		MarbleSet.SetActive(true);

		for (int i = 0; i < SettingsButtons.Count; i++)
		{
			SettingsButtons[i].SetActive(false);
		}

		Audio.PlayClip("Button_Press");
	}



	public void SettingsMenu()
	{
		Debug.Log("Settings Button");

		if (VideoSet.activeInHierarchy)
		{
			VideoSet.SetActive(false);
		}

		if (AudioSet.activeInHierarchy)
		{
			AudioSet.SetActive(false);
		}

		if (MarbleSet.activeInHierarchy)
		{
			MarbleSet.SetActive(false);
		}

		for (int i = 0; i < SettingsButtons.Count; i++)
		{
			SettingsButtons[i].SetActive(true);
		}

		Audio.PlayClip("Button_Press");
	}
}
