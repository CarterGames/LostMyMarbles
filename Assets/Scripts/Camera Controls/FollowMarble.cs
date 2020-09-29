using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class FollowMarble : MonoBehaviour
    {
        [SerializeField] private GameObject marbleFollowPoint;

        private void Update()
        {
            transform.position = marbleFollowPoint.transform.position;
        }
    }
}