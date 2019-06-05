using System.Collections.Generic;
using UnityEngine;


/*


		Universal Audio Managment Script

		Scripts written by: Jonathan Carter (https://jonathan.carter.games)
 
		- Useful for Selcting and playing SFX and pretty much works for any game.


*/


public class AudioManager : MonoBehaviour
{

   public GameObject Sound_Prefab = null;       // Holds the prefab that plays the sound requested
	[HideInInspector]
	public List<string> Sound_Names = new List<string>();       // A list to hold the audioclip names
	[HideInInspector]
	public List<AudioClip> Sound_Clips = new List<AudioClip>();									// A list to hold the audioclips themselves
    public Dictionary<string, AudioClip> Sound_Lib = new Dictionary<string, AudioClip>();       // Dictionary that holds the audio names and clips

	
    private void Start()
	{ 
		GetComponent<AudioSource>().hideFlags = HideFlags.HideInInspector;

		for (int i = 0; i < Sound_Names.Count; i++)         // For loop that populates the dictionary with all the sound assets in the lists
        {
            Sound_Lib.Add(Sound_Names[i], Sound_Clips[i]);
        }
    }

	
	// Fuction to select and play a sound asset from the start with options
    public void PlayClip(string request, float Volume = 1, float Pitch = 1)                   
    {
        if (Sound_Lib.ContainsKey(request))												// If the sound is in the library
        {
            GameObject clip = Instantiate(Sound_Prefab);									// Instantiate a Sound prefab
            clip.GetComponent<AudioSource>().clip = Sound_Lib[request];                     // Get the prefab and add the requested clip to it

			clip.GetComponent<AudioSource>().volume = Volume;
			clip.GetComponent<AudioSource>().pitch = Pitch;

			clip.GetComponent<AudioSource>().Play();										// play the audio from the prefab
			Destroy(clip, clip.GetComponent<AudioSource>().clip.length);					// Destroy the prefab once the clip has finished playing
        }
    }


	// Function to select and play a sound asset from a selected time with options
	public void PlayClipFromTime(string request, float time, float Volume = 1, float Pitch = 1)
	{
		if (Sound_Lib.ContainsKey(request))
		{
			GameObject clip = Instantiate(Sound_Prefab);
			clip.GetComponent<AudioSource>().clip = Sound_Lib[request];
			clip.GetComponent<AudioSource>().time = time;

			clip.GetComponent<AudioSource>().volume = Volume;
			clip.GetComponent<AudioSource>().pitch = Pitch;

			clip.GetComponent<AudioSource>().Play();
			Destroy(clip, clip.GetComponent<AudioSource>().clip.length);
		}
	}


	// Function to select and play a sound asset with a delay and options
	public void PlayClipWithDelay(string request, float delay, float Volume = 1, float Pitch = 1)
    {
        if (Sound_Lib.ContainsKey(request))
        {
            GameObject clip = Instantiate(Sound_Prefab);
            clip.GetComponent<AudioSource>().clip = Sound_Lib[request];

			clip.GetComponent<AudioSource>().volume = Volume;
			clip.GetComponent<AudioSource>().pitch = Pitch;

			clip.GetComponent<AudioSource>().PlayDelayed(delay);							// Only difference, played with a delay rather that right away
            Destroy(clip, clip.GetComponent<AudioSource>().clip.length);
        }
    }


	public void UpdateLibrary()
	{
		for (int i = 0; i < Sound_Names.Count; i++)         // For loop that populates the dictionary with all the sound assets in the lists
		{
			Sound_Lib.Clear();
			Sound_Lib.Add(Sound_Names[i], Sound_Clips[i]);
		}
	}
}