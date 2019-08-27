using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPadScript : MonoBehaviour
{
	public string LevelNumber = "Level#";
	public LevelScores LvlData;
	public SaveScript Save;
	public GameObject LevelSelectUI;


    void Start()
    {
		Save = FindObjectOfType<SaveScript>();

		// Finds the level data for this level
		for (int i = 0; i < Save.LevelData.Count; i++)
		{
			if (Save.LevelData[i].LevelName == LevelNumber)
			{
				LvlData = Save.LevelData[i];
			}
		}
    }


	private void OnTriggerEnter(Collider other)
	{
		// Enable UI
		LevelSelectUI.transform.position = new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y + 1, transform.GetChild(0).position.z);

		// Setup Elements
		LevelSelectUI.GetComponentsInChildren<Text>()[0].text = "Level " + LvlData.LevelName.Substring(LvlData.LevelName.Length - 1);
		//LevelSelectUI.GetComponentsInChildren<Text>()[1].text = "1st: " + LvlData.BestTimeName;
		//LevelSelectUI.GetComponentsInChildren<Text>()[2].text = ConvertTime(LvlData.BestTime);

		LevelSelectUI.transform.parent.GetComponent<Canvas>().enabled = true;
	}



	private void OnTriggerExit(Collider other)
	{
		// Close UI
		LevelSelectUI.transform.parent.GetComponent<Canvas>().enabled = false;
	}


	private string ConvertTime(float Time)
	{
		if (Time == 9999999) { return "99:99:99"; }
		else
		{
			string Mins = Mathf.FloorToInt(Time / 60).ToString("00");
			string Secs = Mathf.Floor((Time % 60)).ToString("00");
			string MilSecs = ((Time * 100) % 100).ToString("00");
			return Mins + ":" + Secs + ":" + MilSecs;
		}
	}
}
