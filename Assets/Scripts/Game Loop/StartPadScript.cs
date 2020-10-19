using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
	public class StartPadScript : MonoBehaviour
	{
		private Vector3 StartPos;       // Start Pos Vector3 to hold the new position

		[Header("Marble Object")]
		public GameObject Marble;       // Gameobject for the Marble object


		private void Start()
		{
			// Setting the StartPos to the position of the object the script is on + 3 on the Y Axis so it starts in the air
			StartPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

			// Setting the position of the Marble object to the StartPos
			Marble.transform.SetPositionAndRotation(StartPos, Quaternion.Euler(0, 0, 0));
		}
	}
}