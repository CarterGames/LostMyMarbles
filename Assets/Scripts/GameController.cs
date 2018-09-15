using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// Enum for the game states (all these scenes need to be in the build settings to work)
// THIS IS IN GLOBAL SCOPE!!! (So it can be referanced by other scripts to change the scenes)
public enum GameStates
{
	Menu,                       // Menu Scene
	LevelSelect,                // Level Select Scene (may end up being another part of the menu scene)
	Level1,                     // First Level
	Credits,                    // Credits Scene
	Quit,                       // Quit Game
};

// Enum for the level states used for the timing of levels and transtitions between levels
public enum LevelStates
{
	Finished,
	Null,
};


public class GameController : MonoBehaviour
{
	
	// Values can't change outside the script
	// used to set the size of the 2d array which holds the best and last times for each level
	private static int NumberOfLevels = 2;
	private static int TimesStored = 2;

	// Initilises a 2 Dimentional array to store the times for each level (could be done by external file if wanted I guess)
	public float[,] Times = new float[NumberOfLevels, TimesStored];

	[Header("Level Variables")]
	// Int for the level number of the level the player is on
	public int LevelNumber = 0;
	public float LevelTimer = 0;


	[Header("Game States")]
	public GameStates E_GameStates;                             // a enum variable of the enum defined in global scope

	// bool for updating the scores on the menu
	public bool UpdateScores = false;





	// When the script starts
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);                          // Don't destroy the object the script is attached to

		Initial();                                              // Runs the initial function for initial game setup
	}




	// Initial function, to run anything that need setting on game start
	private void Initial()
	{
		LoadCurrentScene(E_GameStates);                         // Runs the load scene function
	}

	private void Start()
	{
		LevelTimer = 0;
	}


	public void ChangeLevelState(LevelStates state)
	{
		switch (state)
		{

			case LevelStates.Finished:
				SetLevelLastTime(LevelNumber, LevelTimer);

				if (GetLevelBestTime(LevelNumber) == 0)
				{
					Debug.Log("Best Time IS Set as it was 0");
					SetLevelBestTime(LevelNumber, LevelTimer);
					state = LevelStates.Null;
					break;
				}
				else if ((GetLevelLastTime(LevelNumber)) < (GetLevelBestTime(LevelNumber)))
				{
					Debug.Log("Best Time IS Set as beat the last best time");
					SetLevelBestTime(LevelNumber, LevelTimer);
					state = LevelStates.Null;
					break;
				}
				else
				{
					Debug.Log("Best Time NOT SET!!!");
					ChangeLevelState(LevelStates.Null);
					break;
				}

			case LevelStates.Null:
				break;
		}
	}



	// Load scene function
	public void LoadCurrentScene(GameStates state)
	{
		switch (state)                                          // Switch statement for the different game states
		{
			case GameStates.Menu:                               // Case - Menu (0)
				SceneManager.LoadScene("Menu");
				break;

			case GameStates.LevelSelect:                        // Case - LevelSelect (1)
				SceneManager.LoadScene("LevelSelect");
				break;

			case GameStates.Level1:                             // Case - Level1 (2)
				SceneManager.LoadScene("Level1");
				SetLevelNumber(1);
				break;

			case GameStates.Credits:                            // Case - Credits (3)
				SceneManager.LoadScene("Credits");
				break;

			case GameStates.Quit:                               // Case - Quit (4)
				Application.Quit();
				break;

			default:                                            // Default - Nothing
				break;
		}
	}







	// ------------------------------------------------------ Getters


	// Gets & Returns the LevelNumber variable
	public int GetLevelNumber()
	{
		return LevelNumber;
	}

	// Gets & Returns requested BestTime in the Times Array
	public float GetLevelBestTime(int LevelNumber)
	{
		return Times[LevelNumber, 0];
	}

	// Gets & Returns requested LastTime in the Times Array
	public float GetLevelLastTime(int LevelNumber)
	{
		return Times[LevelNumber, 1];
	}

	// Gets & Returns the Level Timer
	public float GetTimer()
	{
		return LevelTimer;
	}

	// Gets & Returns the Update Scores boolean
	public bool GetUpdateScores()
	{
		return UpdateScores;
	}

	// Gets & Returns the Times Array
	public float[,] GetTimesArray()
	{
		return Times;
	}


	// ------------------------------------------------------ Setters


	// Sets the LevelNumber to the number inputted
	public void SetLevelNumber(int number)
	{
		LevelNumber = number;
	}

	// Sets the BestTime for a level into the Times Array
	public void SetLevelBestTime(int LevelNumber, float time)
	{
		Times[LevelNumber, 0] = time;
	}

	// Sets the LastTIme for a level into the Times Array
	public void SetLevelLastTime(int LevelNumber, float time)
	{
		Times[LevelNumber, 1] = time;
	}

	// Sets the UpdateScores boolean to the inputted value
	public void SetUpdateScores(bool input)
	{
		UpdateScores = input;
	}

	public void SetTmer(float input)
	{
		LevelTimer = input;
	}
}
