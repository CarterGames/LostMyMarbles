using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineMeshes : EditorWindow
{





	[MenuItem("Tools/CombineMeshes")]
	public static void ShowWindow()
	{
		GetWindow<CombineMeshes>("Combine Meshes");
	}




	private void OnGUI()
	{
		if (GUILayout.Button("Combine"))
		{

		}
	}
}
