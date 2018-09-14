using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
//
//			A universal script to change parts of a menu, by disable items in a canvas
//
//

public class CanvasChanger : MonoBehaviour
{

	[Header("Elements in the Canvas to be Disabled")]
	public Text[] TextDisable;
	public Button[] ButtonDisable;

	[Header("Elements in the Canvas to be Enabled")]
	public Text[] TextEnable;
	public Button[] ButtonEnable;



	// Function to disable items
	public void CanvasElementsDisable()
	{

		foreach(Text text in TextDisable)
		{
			text.enabled = false;
		}

		foreach(Button button in ButtonDisable)
		{
			button.gameObject.SetActive(false);
		}
	}


	// Function to enable items
	public void CanvasElementsEnable()
	{

		foreach (Text text in TextEnable)
		{
			text.enabled = true;
		}

		foreach (Button button in ButtonEnable)
		{
			button.gameObject.SetActive(true);
		}

	}

}
