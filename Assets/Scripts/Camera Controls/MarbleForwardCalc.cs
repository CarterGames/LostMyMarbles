using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class MarbleForwardCalc : MonoBehaviour
    {
        [SerializeField] private Transform marble;
        [SerializeField] private Transform cam;

        private Vector3 rot;

        private void Update()
        {
            rot = Quaternion.LookRotation(marble.transform.position - cam.transform.position).eulerAngles;
            rot.x = rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);
        }
    }
}