using UnityEngine;
using System.Collections.Generic;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class MegaSpeed : IPowerup
    {
        public float speedMultiplier = 15f;

        public void UseAbility(Rigidbody rb)
        {
            rb.AddForce(rb.velocity * speedMultiplier, ForceMode.Impulse);
        }
    }
}
