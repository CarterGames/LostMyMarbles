using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColourPickerScript : MonoBehaviour
{

	public int R_Value;
	public int G_Value;
	public int B_Value;
	public int A_Value;

	public Texture2D Palette;

	public Image Rend;
	public Texture Text;
	 
	public Vector2 Coords;
	public Vector2 Tile;

	public Color ColourChosen;


	public GraphicRaycaster Ray;
	public PointerEventData PointerEvent;
	public EventSystem Events;

	private void Start()
	{
		Ray = GetComponent<GraphicRaycaster>();
		Events = FindObjectOfType<EventSystem>().GetComponent<EventSystem>();
	}


	private void Update()
	{

		PointerEvent = new PointerEventData(Events);                        // Set up a new PointerEvent

		PointerEvent.position = Input.mousePosition;                        // Set up the PointerEvent to be where the mouse is

		List<RaycastResult> Results = new List<RaycastResult>();            // Creating a list to store the raycase information

		Ray.Raycast(PointerEvent, Results);



		Debug.Log("Running");

		if (Input.GetMouseButtonDown(0))
		{
			foreach (RaycastResult item in Results)                         // search through the results
			{

				Rend = GetComponent<Image>();
				Text = Rend.mainTexture as Texture2D;

				Debug.Log(item.gameObject.transform.position);
				//Coords = Hit.textureCoord;

				//Coords.x *= Text.width;
				//Coords.y *= Text.height;

				//Tile = Rend.material.mainTextureScale;

				//ColourChosen = Palette.GetPixel(Mathf.FloorToInt(Coords.x * Tile.x), Mathf.FloorToInt(Coords.y * Tile.y));
			}
		}


		//Debug.DrawRay(Hit.transform.position, Hit.transform.forward * 10, Color.yellow);
	}
}