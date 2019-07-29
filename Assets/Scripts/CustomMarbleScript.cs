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
	[Header("Ticks")]
	[Tooltip("Tick used for the colour selecter")]
	public GameObject TickColour;
	[Tooltip("Tick used for the texture selector")]
	public GameObject TickTexture;

	[Header("Marble Material")]
	[Tooltip("The Material used on the marble in game")]
	public Material MarbleMat;

	[Header("Marble Data")]
	[Tooltip("Holds the info for the marble customisations")]
	public MarbleData Data;
	public MarbleData DataOld;

	[Header("Raycasting Stuff")]
	public GraphicRaycaster Raycaster;
	public PointerEventData PointerEventData;
	public EventSystem EventSystem;

	[Header("Lists")]
	public List<Image> Colours;
	public List<Texture> Textures;

	private bool Loaded;
	private bool Setup;

	private SaveScript Save;
	private MenuController Menu;



	void Start()
    {
		Raycaster = GetComponent<GraphicRaycaster>();
		EventSystem = GetComponent<EventSystem>();
		Save = FindObjectOfType<SaveScript>();
		Menu = FindObjectOfType<MenuController>();

		if (!Setup)
		{
			Raycaster = GameObject.Find("SettingsCanvas").GetComponent<GraphicRaycaster>();
			EventSystem = FindObjectOfType<EventSystem>();
			Setup = true;
		}
	}


    void Update()
    {
		// Loads the data from the save file and moves te ticks to the current saved options
		if (!Loaded)
		{
			Save.LoadData();
			Color LoadedCol = new Color(Data.ColorR, Data.ColorG, Data.ColorB);

			for (int i = 0; i < Colours.Count; i++)
			{
				if (Colours[i].color == LoadedCol)
				{
					TickColour.gameObject.transform.SetParent(Colours[i].gameObject.transform);
					TickColour.transform.position = Colours[i].gameObject.transform.position;
					if (!TickColour.activeInHierarchy) { TickColour.SetActive(true); }
				}
			}

			for (int i = 0; i < Textures.Count; i++)
			{
				if (i == Data.SpriteNumber)
				{
					TickTexture.gameObject.transform.SetParent(GameObject.Find("MA:Textures").GetComponentsInChildren<Button>()[i].gameObject.transform);
					TickTexture.transform.position = GameObject.Find("MA:Textures").GetComponentsInChildren<Button>()[i].gameObject.transform.position;
					if (!TickTexture.activeInHierarchy) { TickTexture.SetActive(true); }
				}
			}

			Loaded = true;
		}


		if (Input.GetMouseButtonDown(0))
		{
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
				else if (result.gameObject.transform.parent.name.Contains("Texture"))
				{
					UpdateTextureTick(result.gameObject);
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

		TickColour.gameObject.transform.SetParent(InputColour.transform);
		TickColour.transform.position = InputColour.transform.position;

		if (!TickColour.activeInHierarchy) { TickColour.SetActive(true); }

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


	private void UpdateTextureTick(GameObject Input)
	{
		TickTexture.gameObject.transform.SetParent(Input.transform);
		TickTexture.transform.position = Input.transform.position;

		if (!TickTexture.activeInHierarchy) { TickTexture.SetActive(true); }
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

		Accept();
	}


	public void Accept()
	{
		Save.SaveData();
	}
}
