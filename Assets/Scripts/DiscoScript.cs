using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DiscoScript : MonoBehaviour
{
	public PostProcessProfile DiscoProfile;
	public PostProcessProfile MainProfile;

	public GameObject Marble;

	public List<Color32> Colours;

	public List<Material> FloorPieces;

	public float ColourChange = 2f;

	public bool Dancing;
	private bool IsCoRunning;

    void Start()
    {
		for (int i = 0; i < GetComponentsInChildren<MeshRenderer>().Length; i++)
		{
			FloorPieces.Add(GetComponentsInChildren<MeshRenderer>()[i].material);
		}

		Colours = new List<Color32>();

		Colours.Add(Color.black);
		Colours.Add(Color.blue);
		Colours.Add(Color.clear);
		Colours.Add(Color.cyan);
		Colours.Add(Color.gray);
		Colours.Add(Color.green);
		Colours.Add(Color.magenta);
		Colours.Add(Color.red);
		Colours.Add(Color.white);
		Colours.Add(Color.yellow);
    }


    void Update()
    {
		if (!IsCoRunning)
		{
			StartCoroutine(DanceFloorLights());
		}

		if (!Dancing)
		{
			Camera.main.GetComponent<PostProcessVolume>().profile = MainProfile;
		}
    }



	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Dancing = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Dancing = false;
		}
	}



	private IEnumerator DanceFloorLights()
	{
		IsCoRunning = true;

		for (int i = 0; i < FloorPieces.Count; i++)
		{
			FloorPieces[i].color = RandomColour();
		}

		if (Dancing)
		{
			Camera.main.GetComponent<PostProcessVolume>().profile = DiscoProfile;
			Marble.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-180, 180) * 3, 0, Random.Range(-180, 180) * 3));
		}

		yield return new WaitForSeconds(ColourChange);

		IsCoRunning = false;
	}



	private Color32 RandomColour()
	{
		int RandomNumber = Random.Range(0, 9);
		return Colours[RandomNumber];
	}
}
