using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {


	public float BestTime;
	public float LastTime;

	public int LevelNumber;


	public bool UpdateTimes = false;




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



	public float GetBestTime()
	{
		return BestTime;
	}

	public float GetLastTime()
	{
		return LastTime;
	}

	public int GetLevelNmber()
	{
		return LevelNumber;
	}



	public void SetUpdateTime(bool input)
	{
		UpdateTimes = input;
	}

	public void SetBestTime(float time)
	{
		BestTime = time;
	}

	public void SetLastTime(float time)
	{
		LastTime = time;
	}

	public void SetLevelNumber(int number)
	{
		LevelNumber = number;
	}

}
