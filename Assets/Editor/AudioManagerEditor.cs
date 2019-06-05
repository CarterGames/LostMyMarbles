using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

/*
 * 
 *			Audio Manager Editor Script
 *			
 *			Created by Jonathan Carter
 *				  Carter Games
 * 
 * 
*/ 

[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor
{
	// Colours for the Editor Buttons
	private Color32 ScanCol = new Color32(41, 176, 97, 255);
	private Color32 ScannedCol = new Color32(189, 191, 60, 255);
	private Color32 RedCol = new Color32(190, 42, 42, 255);

	private bool SortedAudio;			// Bool for if the audio has been sorted
	private bool HasScannedOnce;		// Bool for if the scan button has been pressed before
	private string ScanButtonString;	// String for the value of the scan button text

	private List<AudioClip> AudioList;	// List of Audioclips used to add the audio to the library in the Audio Manager Script
	private List<string> AudioStrings;	// List of Strings used to add the names of the audio clips to the library in the Audio Manager Script

	private AudioManager Script;		// Reference to the Audio Manager Script that this script overrides the inspector for


	// When the script first enables - do this stuff!
	private void OnEnable()
	{
		// References the Audio Manager Script
		Script = target as AudioManager;		

		// Adds an Audio Source to the gameobject this script is on if its not already there (used for previewing audio only) 
		// * Hide flags hides it from the inspector so you don't notice it there *
		if (Script.gameObject.GetComponent<AudioSource>())
		{
			Script.gameObject.GetComponent<AudioSource>().hideFlags = HideFlags.HideInInspector;
			Script.GetComponent<AudioSource>().playOnAwake = false;
		}
		else
		{
			Script.gameObject.AddComponent<AudioSource>();
			Script.gameObject.GetComponent<AudioSource>().hideFlags = HideFlags.HideInInspector;
			Script.GetComponent<AudioSource>().playOnAwake = false;
		}
	}


	// Overrides the Inspector of the Audio Manager Script with this stuff...
	public override void OnInspectorGUI()
	{
		Script.GetComponent<AudioSource>().playOnAwake = false;

		// The Path to the audio folder in your project
		string Dir = Application.dataPath + "/audio";

		// Makes the audio directoy if it doesn't exist in your project
		// * This will not create a new folder if you already have an audio folder *
		if (!Directory.Exists(Application.dataPath + "/audio"))
		{
			AssetDatabase.CreateFolder("Assets", "Audio");
		}

		// Checks to see if the Audio Manager Library is not empty
		// * If its not empty then you've pressed scan before, therefore it won't show the scan button again *
		if (Script.Sound_Clips.Count != 0)
		{
			HasScannedOnce = true;
		}

		// Changes the text & colour of the first button based on if you've pressed it before or not
		if (HasScannedOnce) { ScanButtonString = "Re-Scan"; GUI.color = ScannedCol; }
		else { ScanButtonString = "Scan"; GUI.color = ScanCol; }


		// Begins a grouping for the buttons to stay on one line
		EditorGUILayout.BeginHorizontal();


		// The actual Scan button - Runs functions to get the audio from the directory and add it to the library on the Audio Manager Script
		if (GUILayout.Button(ScanButtonString))
		{
			// Init Lists
			AudioList = new List<AudioClip>();
			AudioStrings = new List<string>();

			// Auto filling the lists 
			AddAudioClips();
			AddStrings();

			// Updates the lists 
			Script.Sound_Clips = AudioList;
			Script.Sound_Names = AudioStrings;
			Script.UpdateLibrary();
		}

		// Resets the color of the GUI
		GUI.color = Color.white;


		// The actual Clear button - This just clear the Lists and Library in the Audio Manager Script and resets the Has Scanned bool for the Scan button reverts to green and "Scan"
		if (GUILayout.Button("Clear"))
		{
			Script.Sound_Lib.Clear();
			Script.Sound_Clips.Clear();
			Script.Sound_Names.Clear();
			HasScannedOnce = false;
		}

		// Ends the grouping for the buttons
		EditorGUILayout.EndHorizontal();


		// *** Labels ***
		EditorGUILayout.HelpBox("Items Scanned: " + Script.Sound_Clips.Count + "\n" + "Items in Directory: " + CheckNumberOfFiles(), MessageType.None);

		if (HasScannedOnce)
		{
			DisplayNames();
		}


		Repaint();
		// Shows anything that would normally be on the inspector - unless it has the Hide From Inspector
		// * If uncommented this will only show the script reference as everytinh else from the script is either internal, private or hidden from inspector *
		base.OnInspectorGUI();
	}


	// Adds all the audio clips to the list
	private void AddAudioClips()
	{
		// Makes a new lsit the size of the amount of objects in the path
		List<string> AllFiles = new List<string>(Directory.GetFiles(Application.dataPath + "/audio"));

		// Checks to see if there is anything in the path, if its empty it will not run the rest of the code and instead put a message in the console
		if (AllFiles.Count > 0)
		{
			HasScannedOnce = true;	// Sets the has scanned once to true so the scan button turns into the re-scan button

			foreach (string Thingy in AllFiles)
			{
				string Path = "Assets" + Thingy.Replace(Application.dataPath, "").Replace('\\', '/');

				AudioClip Source = (AudioClip)AssetDatabase.LoadAssetAtPath(Path, typeof(AudioClip));

				AudioList.Add(Source);
			}
		}
		else
		{
			// !Warning Message - shown in the console should there be no audio in the directory been scanned
			Debug.LogWarning("Audio Manager: Please ensure there are Audio files in the directory: " + Application.dataPath + "/Audio");
		}
	}


	// Adds all the strings for the clip names to its list
	private void AddStrings()
	{
		for (int i = 0; i < AudioList.Count; i++)
		{
			if (AudioList[i] == null)
			{
				AudioList.Remove(AudioList[i]);
			}
		}

		for (int i = 0; i < AudioList.Count; i++)
		{
			AudioStrings.Add(AudioList[i].ToString().Replace(" (UnityEngine.AudioClip)", ""));
		}
	}


	// Returns the number of files in the audio directory
	private int CheckNumberOfFiles()
	{
		int FinalCount;
		List<AudioClip> ClipCount = new List<AudioClip>();
		List<string> AllFiles = new List<string>(Directory.GetFiles(Application.dataPath + "/audio"));

		foreach (string Thingy in AllFiles)
		{
			string Path = "Assets" + Thingy.Replace(Application.dataPath, "").Replace('\\', '/');

			AudioClip Source = (AudioClip)AssetDatabase.LoadAssetAtPath(Path, typeof(AudioClip));

			ClipCount.Add(Source);
		}

		FinalCount = ClipCount.Count;

		// divides the final result by 2 as it includes the .meta files in this count which we don't use
		return FinalCount / 2;
	}


	private void DisplayNames()
	{
		string Elements = "";
		bool IsPlaying = false;

		for (int i = 0; i < Script.Sound_Clips.Count; i++)
		{
			Elements = Script.Sound_Names[i];


			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.TextArea(Elements, GUILayout.MaxWidth(200));

			GUI.color = ScanCol;

			if (!Script.GetComponent<AudioSource>().isPlaying)
			{
				if (GUILayout.Button("Preview Clip"))
				{
					Script.GetComponent<AudioSource>().clip = Script.Sound_Clips[i];
					Script.GetComponent<AudioSource>().PlayOneShot(Script.GetComponent<AudioSource>().clip);
				}
			}
			else
			{
				GUI.color = RedCol;

				if (GUILayout.Button("Stop Clip"))
				{
					Script.GetComponent<AudioSource>().Stop();
				}
			}


			GUI.color = Color.white;

			EditorGUILayout.EndHorizontal();
		}
	}
}
