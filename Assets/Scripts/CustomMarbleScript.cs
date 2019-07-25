using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


[Serializable]
public struct MarbleData
{
	public Color32 MarbleColour;
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

	void Start()
    {
		Raycaster = GetComponent<GraphicRaycaster>();
		EventSystem = GetComponent<EventSystem>();
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
		DataOld.MarbleColour = Data.MarbleColour;
		DataOld.MarbleTexture = Data.MarbleTexture;
		Data = new MarbleData();
		Data.MarbleColour = InputColour.color;
		Data.MarbleTexture = DataOld.MarbleTexture;
		UpdateMarble();
	}


	public void ChangeTexture(Image InputMat)
	{
		DataOld.MarbleColour = Data.MarbleColour;
		DataOld.MarbleTexture = Data.MarbleTexture;
		Data = new MarbleData();
		Data.MarbleColour = DataOld.MarbleColour;
		Data.MarbleTexture = InputMat.sprite;
		UpdateMarble();
	}


	private void UpdateMarble()
	{
		MarbleMat.color = Data.MarbleColour;
		MarbleMat.mainTexture = Data.MarbleTexture.texture;
	}
}
