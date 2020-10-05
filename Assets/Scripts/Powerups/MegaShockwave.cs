using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class MegaShockwave : IPowerup
    {
        public float shockwaveForce = 1500f;
        public float shockwaveRadius = 100f;

        public void UseAbility(Rigidbody rb)
        {
            List<Collider> colliders = Physics.OverlapSphere(rb.transform.position, shockwaveRadius).ToList();

            colliders.Remove(rb.gameObject.GetComponent<SphereCollider>());

            for (int i = 0; i < colliders.Count; i++)
            {
                if (colliders[i].gameObject.GetComponent<Rigidbody>() && !colliders[i].gameObject.isStatic)
                {
                    colliders[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(shockwaveForce, rb.gameObject.transform.position, shockwaveRadius);
                }
            }
        }
    }
}
