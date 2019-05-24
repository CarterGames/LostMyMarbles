using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Save Script Namespaces
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveScript : MonoBehaviour
{

	public struct LevelData
	{
		float LevelNo;
		float StarTime;
		LevelScores LevelScore;
	}

	public void SaveGame()
	{
		// does stuff with binrary one assumes :)
		BinaryFormatter BinFormat = new BinaryFormatter();

		// creates a file in the data path /C/users/appdata/......
		FileStream DataFile = File.Create(Application.persistentDataPath + "/gamedata.dat");

		// creates an instance of the game data class...
		GameData Data = new GameData();

		// populating the new instance with the current values in the game


		// Converts to binrary, using the data from the data thingy in a data file
		BinFormat.Serialize(DataFile, Data);

		// Closes the data file
		DataFile.Close();
	}


	public void LoadGame()
	{
		// checks to see if the file exsists, duh...
		if (File.Exists(Application.persistentDataPath + "/gamedata.dat"))
		{
			BinaryFormatter BinFormat = new BinaryFormatter();

			// Makes a local file with the file in the location and opens it :)
			FileStream DataFile = File.Open(Application.persistentDataPath + "/gamedata.dat", FileMode.Open);

			// converts the file to readable thingys :) ( "unbinraryfys" the file )
			GameData Data = (GameData)BinFormat.Deserialize(DataFile);

			// Closes the file
			DataFile.Close();

			// Sets the values to the values that were in the file

		}

	}


}

// holds things we wanna save :)
[Serializable]
class GameData
{

}
