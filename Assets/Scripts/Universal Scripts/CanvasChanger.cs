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

	// Array's of Text & Buttons to be disabled
	[Header("Elements in the Canvas to be Disabled")]
	public Text[] TextDisable;								// the [] makes the array size undefined, which is then defined in the Inspector. meaing it can be a big as needed for its use case
	public Button[] ButtonDisable;

	// Array's of Text & Buttons to be enabled
	[Header("Elements in the Canvas to be Enabled")]
	public Text[] TextEnable;
	public Button[] ButtonEnable;



	// Function to disable items
	public void CanvasElementsDisable()
	{

		foreach(Text text in TextDisable)				// foreach does what it says on the tin, for each Text object in the TextDisable array, do the following...
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
