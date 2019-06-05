using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Canvas TitleScreen;
	public Canvas LevelSelect;
	public Canvas SettingsScreen;

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
}
