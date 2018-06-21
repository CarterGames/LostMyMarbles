using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A Universial Material changer for assets in the game


public class TextureChange : MonoBehaviour
{

	[Header("Textures For The Animation")]
	public Texture[] Textures;                  // Creates an array of textures called "Textures" that is ajustable in the inspector

	[Header("Time Between Animations")]
	public float Offset = 0.5f;                 // Creates a float for the amount of time between animations

	[Header("Renderer That Is On The Asset In Question")]
	public Renderer Rend;						// Creates a renderer while can be selected in the inspector for the asset which the animation is taking effect on

	private int Index;							// Creates a private int for the Index value, as its not needed to be seen and can be called by debug.log if needed


	// Use this for initialization
	void Start ()
	{

		// Makes life easier when refering to the compentent
		Rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		// If there are no extra animations, this stops the script here
		if (Textures.Length == 0)
		{
			return;
		}

		// "Mathf.FloorToInt" - Converts the float time to an int so it can be used with an animation
		// This part calculates to time which the animation should change
		Index = Mathf.FloorToInt(Time.time / Offset);

		// Here the index is divided by the anoumt of animations
		Index = Index % Textures.Length;

		// his changes the rendered texture to the next testure in the sequence
		Rend.material.mainTexture = Textures[Index];
	}
}
