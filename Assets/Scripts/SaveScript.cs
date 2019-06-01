using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Save Script Namespaces
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;


[Serializable]
public struct LevelScores
{
	public float BestTime;
	public string BestTimeName;

	public float SecondBestTime;
	public string SecondBestName;

	public float ThirdBestTime;
	public string ThirdBestName;

	public float LastTime;
	public float StarTime;

	public string LevelName;
	public Sprite LevelImage;
}


public class SaveScript : MonoBehaviour
{
	public List<LevelScores> LevelData;
	public List<string> StarTimes;

	private void Awake()
	{
		LevelData = new List<LevelScores>();
		StarTimes = new List<string>(20);

		for (int i = 0; i < 20; i++)
		{
			LevelData.Add(new LevelScores());
		}

		Setup();
	}

	// Initilise The File if it doesn't exsist
	private void Setup()
	{
		// Goes through the Level Scores and sets up the level names to equal "Level##"
		for (int i = 0; i < LevelData.Count; i++)
		{
			LevelScores Test = new LevelScores();
			Test.LevelName = "Level" + (i + 1);
			LevelData[i] = Test;
		}

		// Sets up the default values for all elements in each Level Score
		if (!File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		{
			List<Sprite> LevelSS = new List<Sprite>();

			for (int i = 0; i < Resources.LoadAll("LevelScreenshots", typeof(Sprite)).Cast<Sprite>().ToList().Count; i++)
			{
				LevelSS.Add(Resources.LoadAll("LevelScreenshots", typeof(Sprite)).Cast<Sprite>().ToList()[i]);
			}

			// Goes through the LevelData and sets it up to have default values
			for (int i = 0; i < LevelData.Count; i++)
			{
				// Creates a temp level scores to hold the new values
				LevelScores Update = new LevelScores();

				// Sets up the default values
				Update.BestTime = 9999999;
				Update.SecondBestTime = 9999999;
				Update.ThirdBestTime = 9999999;
				Update.BestTimeName = LevelData[i].BestTimeName;
				Update.SecondBestName = LevelData[i].SecondBestName;
				Update.ThirdBestName = LevelData[i].ThirdBestName;
				Update.StarTime = LevelData[i].StarTime;
				Update.LastTime = LevelData[i].LastTime;
				Update.LevelName = LevelData[i].LevelName;
				Update.LevelImage = LevelSS[i];

				// Makes the changes to the LevelData
				LevelData[i] = Update;

				// Saves the new values
				SaveData();
			}
		}
		else
		{
			// Loads the data if the file already exsists
			LoadData();
		}
	}


	private void SetupStarTimes()
	{
		if (!File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		{
			
		}
	}

	// Saves the Level Scores to the file
	public void SaveData()
	{
		// does stuff with binrary one assumes :)
		BinaryFormatter BinFormat = new BinaryFormatter();

		FileStream DataFile;

		// creates a file in the data path /C/users/appdata/......
		if (!File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		{
			DataFile = File.Create(Application.persistentDataPath + "/gamedata.ini");
		}
		else
		{
			DataFile = File.Open(Application.persistentDataPath + "/gamedata.ini", FileMode.Open);
		}

		// creates an instance of the game data class...
		GameData Data = new GameData();

		// populating the new instance with the current values in the game
		Data.Level1 = LevelData[0];
		Data.Level2 = LevelData[1];
		Data.Level3 = LevelData[2];
		Data.Level4 = LevelData[3];
		Data.Level5 = LevelData[4];
		Data.Level6 = LevelData[5];
		Data.Level7 = LevelData[6];
		Data.Level8 = LevelData[7];
		Data.Level9 = LevelData[8];
		Data.Level10 = LevelData[9];
		Data.Level11 = LevelData[10];
		Data.Level12 = LevelData[11];
		Data.Level13 = LevelData[12];
		Data.Level14 = LevelData[13];
		Data.Level15 = LevelData[14];
		Data.Level16 = LevelData[15];
		Data.Level17 = LevelData[16];
		Data.Level18 = LevelData[17];
		Data.Level19 = LevelData[18];
		Data.Level20 = LevelData[19];

		// Converts to binrary, using the data from the data thingy in a data file
		BinFormat.Serialize(DataFile, Data);

		// Closes the data file
		DataFile.Close();
	}

	// Load the Level Scores from the file to the LevelData List
	public void LoadData()
	{
		// checks to see if the file exsists, duh...
		if (File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		{
			BinaryFormatter BinFormat = new BinaryFormatter();

			// Makes a local file with the file in the location and opens it :)
			FileStream DataFile = File.Open(Application.persistentDataPath + "/gamedata.ini", FileMode.Open);

			// converts the file to readable thingys :) ( "unbinraryfys" the file )
			GameData Data = (GameData)BinFormat.Deserialize(DataFile);

			// Closes the file
			DataFile.Close();

			// Sets the values to the values that were in the file
			LevelData[0] = Data.Level1;
			LevelData[1] = Data.Level2;
			LevelData[2] = Data.Level3;
			LevelData[3] = Data.Level4;
			LevelData[4] = Data.Level5;
			LevelData[5] = Data.Level6;
			LevelData[6] = Data.Level7;
			LevelData[7] = Data.Level8;
			LevelData[8] = Data.Level9;
			LevelData[9] = Data.Level10;
			LevelData[10] = Data.Level11;
			LevelData[11] = Data.Level12;
			LevelData[12] = Data.Level13;
			LevelData[13] = Data.Level14;
			LevelData[14] = Data.Level15;
			LevelData[15] = Data.Level16;
			LevelData[16] = Data.Level17;
			LevelData[17] = Data.Level18;
			LevelData[18] = Data.Level19;
			LevelData[19] = Data.Level20;
		}
	}
}

// Class that stores the values 
[Serializable]
class GameData
{
	public LevelScores Level1;
	public LevelScores Level2;
	public LevelScores Level3;
	public LevelScores Level4;
	public LevelScores Level5;
	public LevelScores Level6;
	public LevelScores Level7;
	public LevelScores Level8;
	public LevelScores Level9;
	public LevelScores Level10;
	public LevelScores Level11;
	public LevelScores Level12;
	public LevelScores Level13;
	public LevelScores Level14;
	public LevelScores Level15;
	public LevelScores Level16;
	public LevelScores Level17;
	public LevelScores Level18;
	public LevelScores Level19;
	public LevelScores Level20;
}