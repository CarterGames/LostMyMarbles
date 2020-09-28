using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class FreezeLocalRotation : MonoBehaviour
    {
        private Quaternion rotation;

        private void Start()
        {
            rotation = transform.localRotation;
        }

        private void LateUpdate()
        {
            transform.localRotation = rotation;
        }
    }
}