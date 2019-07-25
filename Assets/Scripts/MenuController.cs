using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Canvas TitleScreen;
	public Canvas LevelSelect;
	public Canvas SettingsScreen;

	public GameObject VideoSet;
	public GameObject AudioSet;
	public GameObject MarbleSet;

	private AudioManager Audio;

	private void Start()
	{
		Audio = FindObjectOfType<AudioManager>();
		TitleScreen.enabled = true;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = false;
	}


	public void Play()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = true;
		SettingsScreen.enabled = false;
		Audio.PlayClip("Button_Press");
	}

	public void Settings()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = true;
		Audio.PlayClip("Button_Press");
	}

	public void Menu()
	{
		TitleScreen.enabled = true;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = false;
		Audio.PlayClip("Button_Press");
	}


	public void VideoSettings()
	{
		if (AudioSet.activeInHierarchy)
		{
			AudioSet.SetActive(false);
		}

		if (MarbleSet.activeInHierarchy)
		{
			MarbleSet.SetActive(false);
		}

		VideoSet.SetActive(true);
	}


	public void AudioSettings()
	{
		if (VideoSet.activeInHierarchy)
		{
			VideoSet.SetActive(false);
		}

		if (MarbleSet.activeInHierarchy)
		{
			MarbleSet.SetActive(false);
		}

		AudioSet.SetActive(true);
	}


	public void MarbleSettings()
	{
		if (VideoSet.activeInHierarchy)
		{
			VideoSet.SetActive(false);
		}

		if (AudioSet.activeInHierarchy)
		{
			AudioSet.SetActive(false);
		}

		MarbleSet.SetActive(true);
	}
}
