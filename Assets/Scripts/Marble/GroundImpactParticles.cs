using UnityEngine;
using System.Collections.Generic;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class GroundImpactParticles : MonoBehaviour
    {
        [SerializeField] private GameObject groundHitParticlesPrefab;
        private List<GameObject> groundHitParticlesPool;
        internal bool hasPlayedParticles = false;


        private void Start()
        {
            groundHitParticlesPool = new List<GameObject>();

            for (int i = 0; i < 3; i++)
            {
                GameObject _go = Instantiate(groundHitParticlesPrefab);
                groundHitParticlesPool.Add(_go);
            }
        }

        public void SpawnImpactParticles()
        {
            for (int i = 0; i < groundHitParticlesPool.Count; i++)
            {
                if (!groundHitParticlesPool[i].activeInHierarchy)
                {
                    groundHitParticlesPool[i].transform.position = transform.position;
                    groundHitParticlesPool[i].SetActive(true);
                    groundHitParticlesPool[i].GetComponent<ParticleSystem>().Play();
                    break;
                }
            }
        }
    }
}