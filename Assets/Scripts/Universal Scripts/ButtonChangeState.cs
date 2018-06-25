using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeState : MonoBehaviour
{

	[Header("Variables")]
	public GameObject MenuManager;				// Gameobject for the Menu Manager
	public GameStates state;					// Getting the global scope Enum from the Menu Manager

	private MenuManager Manager;				// Getting the menu manager script

	// Use this for initialization
	void Start ()
	{
		Manager = MenuManager.GetComponent<MenuManager>();		// Just makes the manager variable lead to get the menu manager script
	}

	public void SwapState()
	{
		Manager.LoadCurrentScene(state);						// loads the scene selected in the inspector
	}
}
