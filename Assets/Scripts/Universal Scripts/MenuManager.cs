using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Enum for the game states (all these scenes need to be in the build settings to work)
// THIS IS IN GLOBAL SCOPE!!! (So it can be referanced by other scripts to change the scenes)
public enum GameStates
{
	Menu,						// Menu Scene
	LevelSelect,				// Level Select Scene (may end up being another part of the menu scene)
	Level1,						// First Level
	Credits,					// Credits Scene
	Quit,						// Quit Game
};

// Script Start
public class MenuManager : MonoBehaviour
{
	[Header("Game States")]
	public GameStates E_GameStates;                             // a enum variable of the enum defined in global scope

	public GameObject Manager;

	private Manager ManagerScript;
	// When the script starts
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);                          // Don't destroy the object the script is attached to

		Initial();												// Runs the initial function for initial game setup
	}

	private void Start()
	{
		ManagerScript = Manager.GetComponent<Manager>();
	}

	// Initial function, to run anything that need setting on game start
	private void Initial()
	{
		LoadCurrentScene(E_GameStates);							// Runs the load scene function
	}

	// Load scene function
	public void LoadCurrentScene(GameStates state)
	{
		switch(state)											// Switch statement for the different game states
		{
			case GameStates.Menu:								// Case - Menu (0)
				SceneManager.LoadScene("Menu");
				break;

			case GameStates.LevelSelect:						// Case - LevelSelect (1)
				SceneManager.LoadScene("LevelSelect");
				break;

			case GameStates.Level1:								// Case - Level1 (2)
				SceneManager.LoadScene("Level1");
				ManagerScript.SetLevelNumber(1);
				break;

			case GameStates.Credits:							// Case - Credits (3)
				SceneManager.LoadScene("Credits");
				break;

			case GameStates.Quit:								// Case - Quit (4)
				Application.Quit();
				break;

			default:											// Default - Nothing
				break;
		}
	}

	// Update every frame
	void Update()
	{
		if (Input.GetButton("Cancel"))							// If the button mapped cancel is pressed
		{
			LoadCurrentScene(GameStates.Quit);					// Quit the appilcation (only works on a built version of the game)
		}
	}
}
