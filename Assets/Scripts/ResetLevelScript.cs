using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelScript : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Scene ThisScene = SceneManager.GetActiveScene();
			SceneManager.LoadSceneAsync(ThisScene.ToString());
		}
	}
}