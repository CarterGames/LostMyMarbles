using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using System;
//using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CustomEditor(typeof(SaveScript))]
public class SaveScriptEditor : Editor
{
	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("Purge Data File"))
		{
			File.Delete(Application.persistentDataPath + "/gamedata.ini");
		}

		base.OnInspectorGUI();
	}
}
