using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameStates
{
	Menu,
	LevelSelect,
	Level1,
	Credits,
	Quit,
};


public class MenuManager : MonoBehaviour
{

	public GameStates E_GameStates;


	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Initial();
	}

	private void Initial()
	{
		LoadCurrentScene(E_GameStates);
	}


	public void LoadCurrentScene(GameStates state)
	{
		switch(state)
		{
			case GameStates.Menu:
				SceneManager.LoadScene("Menu");
				break;

			case GameStates.LevelSelect:
				SceneManager.LoadScene("LevelSelect");
				break;

			case GameStates.Level1:
				SceneManager.LoadScene("Level1");
				break;

			case GameStates.Credits:
				SceneManager.LoadScene("Credits");
				break;

			case GameStates.Quit:
				Application.Quit();
				break;

			default:
				break;
		}
	}

	void Update()
	{
		if (Input.GetButton("Cancel"))
		{
			LoadCurrentScene(GameStates.Quit);
		}
	}
}
