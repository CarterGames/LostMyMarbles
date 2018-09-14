using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreUpdate : MonoBehaviour
{


	[Header("Text & Manager Object")]
	public Text ScoreText;
	public GameObject GameManager;

	private GameController ControllerScript;
	private int LevelNo;

	// Use this for initialization
	private void Start()
	{
		ControllerScript = GameManager.GetComponent<GameController>();

		LevelNo = ControllerScript.GetLevelNumber();

		ScoreText.text = "Best Score :  " + ControllerScript.GetLevelBestTime(LevelNo);
	}

	private void Update()
	{

		if (ControllerScript.GetUpdateScores() == true)
		{
			ControllerScript.SetUpdateScores(false);
			ScoreText.text = "Best Score :  " + ControllerScript.GetLevelBestTime(LevelNo);
		}


	}
}
