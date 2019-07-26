using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


// What holds the data about the marble so it can be saved.
[Serializable]
public struct MarbleData
{
	public float ColorR;
	public float ColorG;
	public float ColorB;

	public int SpriteNumber;
}


public class CustomMarbleScript : MonoBehaviour
{
	public GameObject Tick;

	public Material MarbleMat;

	public MarbleData Saved;
	public MarbleData DataOld;
	public MarbleData Data;

	public GraphicRaycaster Raycaster;
	public PointerEventData PointerEventData;
	public EventSystem EventSystem;

	public List<Texture> Textures;

	private SaveScript Save;
	private MenuController Menu;

	void Start()
    {
		Raycaster = GetComponent<GraphicRaycaster>();
		EventSystem = GetComponent<EventSystem>();
		Save = FindObjectOfType<SaveScript>();
		Menu = FindObjectOfType<MenuController>();
	}


    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			if ((Raycaster == null) && (EventSystem == null))
			{
				Raycaster = GameObject.Find("SettingsCanvas").GetComponent<GraphicRaycaster>();
				EventSystem = FindObjectOfType<EventSystem>();
			}

			PointerEventData = new PointerEventData(EventSystem);
			PointerEventData.position = Input.mousePosition;

			List<RaycastResult> results = new List<RaycastResult>();

			Raycaster.Raycast(PointerEventData, results);

			foreach (RaycastResult result in results)
			{
				if (result.gameObject.transform.parent.name.Contains("Colour"))
				{
					ChangeColour(result.gameObject.GetComponent<Image>());
				}
			}
		}
	}


	public void ChangeColour(Image InputColour)
	{
		DataOld.ColorR = Data.ColorR;
		DataOld.ColorG = Data.ColorG;
		DataOld.ColorB = Data.ColorB;
		DataOld.SpriteNumber = Data.SpriteNumber;

		Data = new MarbleData();
		Data.ColorR = InputColour.color.r;
		Data.ColorG = InputColour.color.g;
		Data.ColorB = InputColour.color.b;
		Data.SpriteNumber = DataOld.SpriteNumber;

		Tick.gameObject.transform.SetParent(InputColour.transform);
		Tick.transform.position = InputColour.transform.position;

		UpdateMarble();
	}


	public void ChangeTexture(int Number)
	{
		DataOld.ColorR = Data.ColorR;
		DataOld.ColorG = Data.ColorG;
		DataOld.ColorB = Data.ColorB;
		DataOld.SpriteNumber = Data.SpriteNumber;

		Data = new MarbleData();
		Data.ColorR = DataOld.ColorR;
		Data.ColorG = DataOld.ColorG;
		Data.ColorB = DataOld.ColorB;
		Data.SpriteNumber = Number;
		UpdateMarble();
	}


	private void UpdateMarble()
	{
		MarbleMat.color = new Color(Data.ColorR, Data.ColorG, Data.ColorB, 255);

		switch (Data.SpriteNumber)
		{
			case 0:
				MarbleMat.SetTexture("_MainTex", Textures[0]);
				break;
			case 1:
				MarbleMat.SetTexture("_MainTex", Textures[1]);
				break;
			case 2:
				MarbleMat.SetTexture("_MainTex", Textures[2]);
				break;
			case 3:
				MarbleMat.SetTexture("_MainTex", Textures[3]);
				break;
			default:
				break;
		}
	}


	public void Accept()
	{
		Save.SaveData();
		Saved = Data;
	}

	public void Reject()
	{
		Data = Saved;
		Save.SaveData();
		Menu.SettingsMenu();
	}
}
