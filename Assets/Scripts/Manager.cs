using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {



	public float BestTime;
	public float LastTime;

	public int LevelNumber;


	public bool UpdateTimes = false;

	// Values can't change
	private static int NumberOfLevels = 2;
	private static int TimesStored = 1;

	// Initilises a 2 Dimentional array to store the times for each level (could be done by external file if wanted I guess)
	public float[,] Times = new float[NumberOfLevels,TimesStored];


	private void Initial()
	{
		BestTime = 0;
		LastTime = 0;
	}



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


// ------------------------------------------------------ Getters

	// Gets & Returns the BestTime variable
	public float GetBestTime()
	{
		return BestTime;
	}

	// Gets & Returns the LastTime variable
	public float GetLastTime()
	{
		return LastTime;
	}

	// Gets & Returns the LevelNumber variable
	public int GetLevelNmber()
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



	// ------------------------------------------------------ Setters

	// Sets the bool to update times to the inputted value
	public void SetUpdateTime(bool input)
	{
		UpdateTimes = input;
	}

	// Sets the BestTime to the time inputted
	public void SetBestTime(float time)
	{
		BestTime = time;
	}

	// Sets the LastTime to the time inputted
	public void SetLastTime(float time)
	{
		LastTime = time;
	}

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

}
