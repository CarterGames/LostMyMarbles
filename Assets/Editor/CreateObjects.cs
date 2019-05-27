using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateObjects : EditorWindow
{

	public Object OBJ;

	private List<Object> ListObjects;

	private int NumberofItems;

	private bool ChooseObjects;
	private bool AreFieldsGenerated;

	// Creates the Menu Directory - ShowWindow() is the function called when this is pressed
	[MenuItem("Tools/CreateObjects")]
	public static void ShowWindow()
	{
		// Creates an Editor Window when menu button is pressed under Tools/CreateObjects, it'll only let you have one out at a time
		GetWindow<CreateObjects>("Create Objects");
	}


	// WHhat is shown on the window
	private void OnGUI()
	{
		EditorGUILayout.HelpBox("Use this to spawn prefabs into a scene", MessageType.Info);

		if (!ChooseObjects)
		{
			NumberofItems = EditorGUILayout.IntField("Number of Objects: ", NumberofItems);
		}


		ChooseObjects = GUILayout.Toggle(ChooseObjects, "Choose", "Button");

		if (ChooseObjects)
		{
			ListObjects = new List<Object>(NumberofItems);

			if (ListObjects.Count != NumberofItems)
			{
				for (int i = 0; i < NumberofItems; i++)
				{
					ListObjects.Add(null);
				}

				AreFieldsGenerated = false;
			}

			Debug.Log(ListObjects.Count);


			if (!AreFieldsGenerated)
			{
				for (int i = 0; i < ListObjects.Count; i++)
				{
					Object Temp = new Object();
					Temp = (EditorGUILayout.ObjectField("Element " + i, Temp, typeof(GameObject), true));

					//if (Temp != ListObjects[i])
					//{
					//	ListObjects[i] = Temp;
					//}
				}

				AreFieldsGenerated = true;
			}
		}



		//if (NumberofItems > 0)
		//{
		//	for (int i = 0; i < NumberofItems; i++)
		//	{
		//		Objects.Add(null);
		//	}

		//	for (int i = 0; i < NumberofItems; i++)
		//	{
		//		OBJ = EditorGUILayout.ObjectField("Element " + i, OBJ, typeof(GameObject), true);

		//		if (OBJ != null)
		//		{
		//			Objects[i] = OBJ;
		//			Debug.Log(Objects.Count);
		//		}
		//	}
		//}
	}
}
