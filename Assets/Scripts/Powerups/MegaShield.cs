using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class MegaShield : MonoBehaviour, IPowerup
    {
        private bool isCoR = false;
        public float shieldDuration = 5f;


        public void UseAbility(Rigidbody rb)
        {
            if (!isCoR)
            {
                StartCoroutine(ShieldCo(rb));
            }
        }


        private IEnumerator ShieldCo(Rigidbody rb)
        {
            rb.gameObject.layer = LayerMask.NameToLayer("CantTouchThis");
            yield return new WaitForSeconds(shieldDuration);
            rb.gameObject.layer = LayerMask.NameToLayer("Default");
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}