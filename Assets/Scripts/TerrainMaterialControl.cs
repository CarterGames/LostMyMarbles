using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class TerrainMaterialControl : MonoBehaviour
    {
        [SerializeField] private bool shouldDisableMarbles;
        [SerializeField] private float _phyDrag;
        private float _storedRBDrag;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerController>().canUseControls && other.GetComponent<PlayerController>())
                {
                    if (shouldDisableMarbles)
                    {
                        other.GetComponent<PlayerController>().canUseControls = false;
                    }

                    _storedRBDrag = other.GetComponent<Rigidbody>().drag;
                    other.GetComponent<Rigidbody>().drag = _phyDrag;
                }
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerController>())
                {
                    if (shouldDisableMarbles)
                    {
                        other.GetComponent<PlayerController>().canUseControls = true;
                    }

                    other.GetComponent<Rigidbody>().drag = _storedRBDrag;
                }
            }
        }
    }
}