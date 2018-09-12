using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


	// Identifies the level being timed
	public int LevelNumber;
	

	public enum LevelStates
	{
		Loading,
		Started,
		Finished
	}

	//public int state;

	public float LevelTimer;

	public GameObject Manager;
	public Text DisplayText;

	private Manager ManagerScript;
	private ReadySetGo ReadyScript;


	// Use this for initialization
	void Start ()
	{
		ManagerScript = Manager.GetComponent<Manager>();
		LevelNumber = ManagerScript.GetLevelNmber();
		ReadyScript = DisplayText.GetComponent<ReadySetGo>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ReadyScript.GetTimer() > 5f)
		{
			ChangeLevelState(LevelStates.Started);
		}
		else
		{
			ChangeLevelState(LevelStates.Loading);
		}
	}

	public void ChangeLevelState(LevelStates state)
	{
		switch (state)
		{
			case LevelStates.Loading:
				Debug.Log("Loading");
				break;

			case LevelStates.Started:
				Debug.Log("Started");
				LevelTimer = LevelTimer + 1 * Time.deltaTime;
				break;
			case LevelStates.Finished:
				Debug.Log("Finished");
				ManagerScript.SetLevelLastTime(LevelNumber, LevelTimer);
				break;
		}
	}


}
