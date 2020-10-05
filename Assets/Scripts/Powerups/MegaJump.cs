using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class MegaJump : IPowerup
    {
        public float forceAmount = 300f;

        public MegaJump()
        {
        }

        public MegaJump(float newForce)
        {
            forceAmount = newForce;
        }

        public void UseAbility(Rigidbody rb)
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }
    }
}