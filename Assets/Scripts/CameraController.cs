using UnityEngine;


namespace CarterGames.LostMyMarbles
{
	/// <summary>
	/// Class | Controls the camera movement for the player
	/// </summary>
	public class CameraController : MonoBehaviour
	{
		// References to the Marble and Marble forward which determins the foward direction for movement
		[SerializeField] private  GameObject marble;
		[SerializeField] private GameObject marbleForward;
		[SerializeField] private Camera cam;
		[SerializeField] private Transform camTransform;

		// Rotation speeds, controls how fast the mouse movement is
		[SerializeField] private float rotSpdUpDown;
		[SerializeField] private float rotSpdLeftRight;

		// Bool used to disable this script partially when the player hits the end pad
		[SerializeField] internal bool camEnabled = true;


		private Vector3 _startPos;
		private Quaternion _startRot;


        private void Start()
        {
			_startPos = cam.transform.position;
			_startRot = cam.transform.rotation;
        }


        private void Update()
		{
			if (camEnabled)
			{
				// New Vector3 for the new position when it gets updated
				Vector3 _newPos = marble.transform.position;

				// Sets the new position

				transform.position = new Vector3(_newPos.x + _startPos.x, _startPos.y, _newPos.z + _startPos.z);
				marbleForward.transform.position = _newPos;
			}
            else
            {
				transform.position = marble.transform.position;
            }
		}
	}
}