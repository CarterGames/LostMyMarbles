using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public enum PowerupOptions { None, MegaJump, Tracktion, Bouncy, SpeedBoost, Shockwave, Shield };

    public class PowerupScript : MonoBehaviour
    {
        private PlayerController player;
        public PowerupOptions powerUp;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>())
            {
                player = other.gameObject.GetComponent<PlayerController>();

                if (player.currentPowerUp != PowerupOptions.None || player.currentPowerUp != powerUp )
                {
                    // sets the player up to have a powerup.
                    player.currentPowerUp = powerUp;

                    // disables this power up for reuse.
                    gameObject.SetActive(false);
                }
            }
        }
    }
}