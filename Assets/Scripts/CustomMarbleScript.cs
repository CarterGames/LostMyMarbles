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
	public Sprite MarbleTexture;
}


public class CustomMarbleScript : MonoBehaviour
{
	public Material MarbleMat;

	public MarbleData DataOld;
	public MarbleData Data;

	public GraphicRaycaster Raycaster;
	public PointerEventData PointerEventData;
	public EventSystem EventSystem;

	private SaveScript Save;

	void Start()
    {
		Raycaster = GetComponent<GraphicRaycaster>();
		EventSystem = GetComponent<EventSystem>();
		Save = FindObjectOfType<SaveScript>();
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
				else if (result.gameObject.transform.parent.name.Contains("Texture"))
				{
					ChangeTexture(result.gameObject.GetComponent<Image>());
				}
			}
		}
	}


	public void ChangeColour(Image InputColour)
	{
		DataOld.ColorR = Data.ColorR;
		DataOld.ColorG = Data.ColorG;
		DataOld.ColorB = Data.ColorB;
		DataOld.MarbleTexture = Data.MarbleTexture;
		Data = new MarbleData();
		Data.ColorR = InputColour.color.r;
		Data.ColorG = InputColour.color.g;
		Data.ColorB = InputColour.color.b;
		Data.MarbleTexture = DataOld.MarbleTexture;
		UpdateMarble();
	}


	public void ChangeTexture(Image InputMat)
	{
		DataOld.ColorR = Data.ColorR;
		DataOld.ColorG = Data.ColorG;
		DataOld.ColorB = Data.ColorB;
		DataOld.MarbleTexture = Data.MarbleTexture;
		Data = new MarbleData();
		Data.ColorR = DataOld.ColorR;
		Data.ColorG = DataOld.ColorG;
		Data.ColorB = DataOld.ColorB;
		Data.MarbleTexture = InputMat.sprite;
		UpdateMarble();
	}


	private void UpdateMarble()
	{
		MarbleMat.color = new Color(Data.ColorR, Data.ColorG, Data.ColorB, 255);
		if (Data.MarbleTexture != null)
		{
			MarbleMat.mainTexture = Data.MarbleTexture.texture;
		}
		Save.SaveData();
	}
}
