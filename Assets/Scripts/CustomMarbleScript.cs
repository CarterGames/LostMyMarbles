using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class CustomMarbleScript : MonoBehaviour
{
    [Header("Data")]
    public MarbleData Data;

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

	[Header("Raycasting Stuff")]
	public GraphicRaycaster Raycaster;
	public PointerEventData PointerEventData;
	public EventSystem EventSystem;

	[Header("Lists")]
	public List<Image> Colours;
	public List<Texture> Textures;

	private bool Loaded;
	private bool Setup;

	private MenuController Menu;



	void Start()
    {
		Raycaster = GetComponent<GraphicRaycaster>();
		EventSystem = GetComponent<EventSystem>();
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
            Color LoadedCol = Data.GetColour();
           
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
                if (i == Data.GetTexture())
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
					Data.SetColour(result.gameObject.GetComponent<Image>());
                }
				else if (result.gameObject.transform.parent.name.Contains("Texture"))
				{
                    UpdateTextureTick(result.gameObject);
                }
			}
		}
	}


	private void UpdateTextureTick(GameObject Input)
	{
        UpdateMarble();

        TickTexture.gameObject.transform.SetParent(Input.transform);
		TickTexture.transform.position = Input.transform.position;

		if (!TickTexture.activeInHierarchy) { TickTexture.SetActive(true); }
	}


    public void UpdateMarble()
    {
        MarbleMat.color = Data.GetColour();

        switch (Data.GetTexture())
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
}
