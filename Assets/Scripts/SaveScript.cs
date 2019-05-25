using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Save Script Namespaces
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
}


public class SaveScript : MonoBehaviour
{
	public List<LevelScores> PerLevelData;

	private void Start()
	{
		//if (File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		//{
		//	LoadData();
		//}
		//else
		//{
		//	CreateFile();
		//}
		PerLevelData = new List<LevelScores>();

		for (int i = 0; i < 20; i++)
		{
			PerLevelData.Add(new LevelScores());
		}

		for (int i = 0; i < PerLevelData.Count; i++)
		{
			LevelScores Test = new LevelScores();
			Test.LevelName = "Level" + (i + 1);
			PerLevelData[i] = Test;
		}

		Debug.Log(PerLevelData.Count);
		Debug.Log(PerLevelData[0].LevelName);

		if (!File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		{
			for (int i = 0; i < PerLevelData.Count; i++)
			{
				LevelScores Update = new LevelScores();
				Update.BestTime = 9999999;
				Update.SecondBestTime = 9999999;
				Update.ThirdBestTime = 9999999;
				PerLevelData[i] = Update;
				Debug.Log("Reset Scores");

				Debug.Log(PerLevelData[0].BestTime);

				SaveData();
			}
		}
		else
		{
			LoadData();
		}
	}


	public void CreateFile()
	{
		FileStream DataFile;
		DataFile = File.Create(Application.persistentDataPath + "/gamedata.ini");
		DataFile.Close();
	}

	public void SaveData()
	{
		// does stuff with binrary one assumes :)
		BinaryFormatter BinFormat = new BinaryFormatter();

		FileStream DataFile;

		// creates a file in the data path /C/users/appdata/......
		//if (!File.Exists(Application.persistentDataPath + "/gamedata.ini"))
		//{
			DataFile = File.Create(Application.persistentDataPath + "/gamedata.ini");
		//}
		//else
		//{
		//	DataFile = File.Open(Application.persistentDataPath + "/gamedata.ini", FileMode.Open);
		//}

		// creates an instance of the game data class...
		GameData Data = new GameData();

		// populating the new instance with the current values in the game
		Data.Level1 = PerLevelData[0];
		Data.Level2 = PerLevelData[1];
		Data.Level3 = PerLevelData[2];
		Data.Level4 = PerLevelData[3];
		Data.Level5 = PerLevelData[4];
		Data.Level6 = PerLevelData[5];
		Data.Level7 = PerLevelData[6];
		Data.Level8 = PerLevelData[7];
		Data.Level9 = PerLevelData[8];
		Data.Level10 = PerLevelData[9];
		Data.Level11 = PerLevelData[10];
		Data.Level12 = PerLevelData[11];
		Data.Level13 = PerLevelData[12];
		Data.Level14 = PerLevelData[13];
		Data.Level15 = PerLevelData[14];
		Data.Level16 = PerLevelData[15];
		Data.Level17 = PerLevelData[16];
		Data.Level18 = PerLevelData[17];
		Data.Level19 = PerLevelData[18];
		Data.Level20 = PerLevelData[19];

		Debug.Log(PerLevelData[0].LastTime);
		Debug.Log(PerLevelData[0].BestTime);
		Debug.Log(PerLevelData[0].SecondBestTime);

		// Converts to binrary, using the data from the data thingy in a data file
		BinFormat.Serialize(DataFile, Data);

		// Closes the data file
		DataFile.Close();
	}


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
			PerLevelData[0] = Data.Level1;
			PerLevelData[1] = Data.Level2;
			PerLevelData[2] = Data.Level3;
			PerLevelData[3] = Data.Level4;
			PerLevelData[4] = Data.Level5;
			PerLevelData[5] = Data.Level6;
			PerLevelData[6] = Data.Level7;
			PerLevelData[7] = Data.Level8;
			PerLevelData[8] = Data.Level9;
			PerLevelData[9] = Data.Level10;
			PerLevelData[10] = Data.Level11;
			PerLevelData[11] = Data.Level12;
			PerLevelData[12] = Data.Level13;
			PerLevelData[13] = Data.Level14;
			PerLevelData[14] = Data.Level15;
			PerLevelData[15] = Data.Level16;
			PerLevelData[16] = Data.Level17;
			PerLevelData[17] = Data.Level18;
			PerLevelData[18] = Data.Level19;
			PerLevelData[19] = Data.Level20;
		}
	}
}

// holds things we wanna save :)
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
