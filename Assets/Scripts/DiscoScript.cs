using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoScript : MonoBehaviour
{


	public List<Color32> Colours;

	public List<Material> FloorPieces;

	public float ColourChange;

	private bool IsCoRunning;

    void Start()
    {
		for (int i = 0; i < GetComponentsInChildren<MeshRenderer>().Length; i++)
		{
			FloorPieces.Add(GetComponentsInChildren<MeshRenderer>()[i].material);
		}
		
		
    }


    void Update()
    {
		if (!IsCoRunning)
		{
			StartCoroutine(DanceFloorLights());
		}
    }


	private IEnumerator DanceFloorLights()
	{
		for (int i = 0; i < FloorPieces.Count; i++)
		{
			FloorPieces[i].color = RandomColour();
		}

		yield return new WaitForSeconds(ColourChange);
	}



	private Color32 RandomColour()
	{
		int RandomNumber = Random.Range(0, 9);
		return Colours[RandomNumber];
	}
}
