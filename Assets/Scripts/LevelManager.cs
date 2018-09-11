using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	// Identifies the level being timed
	public int LevelNumber;
	

	public enum LevelStates
	{
		Loading,
		Started,
		Finished
	}

	public int state;

	public float Timer;

	public GameObject Manager;
	private Manager ManagerScript;


	// Use this for initialization
	void Start ()
	{
		ManagerScript = Manager.GetComponent<Manager>();
		LevelNumber = ManagerScript.GetLevelNmber();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{
			case LevelStates.Started:
				Timer++;
				break;
		}
	}
}
