using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public Canvas TitleScreen;
	public Canvas LevelSelect;
	public Canvas SettingsScreen;

	private void Start()
	{
		TitleScreen.enabled = true;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = false;
	}


	public void Play()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = true;
		SettingsScreen.enabled = false;
	}

	public void Settings()
	{
		TitleScreen.enabled = false;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = true;
	}

	public void Menu()
	{
		TitleScreen.enabled = true;
		LevelSelect.enabled = false;
		SettingsScreen.enabled = false;
	}
}
