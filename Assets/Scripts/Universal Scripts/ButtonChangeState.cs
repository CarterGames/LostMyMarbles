using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeState : MonoBehaviour
{

	public GameObject MenuManager;
	public GameStates state;

	private MenuManager Manager;

	// Use this for initialization
	void Start ()
	{
		Manager = MenuManager.GetComponent<MenuManager>();
	}

	public void SwapState()
	{
		Manager.LoadCurrentScene(state);
	}
}
