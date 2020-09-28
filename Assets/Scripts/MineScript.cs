using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CarterGames.LostMyMarbles
{
	public class MineScript : MonoBehaviour
	{
		[Header("Mine Properties")]
		[Tooltip("Amount of Power the explosion has...")]
		[Range(100f, 250f)]
		[SerializeField] private float ExplosionPower = 150;

		[Tooltip("Radius the explosion has...")]
		[Range(50f, 125f)]
		[SerializeField] private float ExplosionRadius = 75;

		[Tooltip("Amount of upward momentium the mine has...")]
		[Range(25f, 100f)]
		[SerializeField] private float ExplosionUpwardPower = 50;


		[Header("Mine Spawning Properties")]
		[Tooltip("Does the mine respawn once it has been activated.")]
		public bool RespawnMine = false;
		[Tooltip("How long will it take for the mine to respawn.")]
		public float RespawnTime = 3;


		[Header("Mine Particles")]
		[Tooltip("Mine Explosion Particles")]
		public ParticleSystem ExplosionParticles;
		[Tooltip("Mine Smoke Particles")]
		public ParticleSystem SmokeParticles;

		[Header("Mine Debug")]
		[Tooltip("Enable if you want to detonate the mines with mouse 0")]
		public bool DebugMine = false;

		// Check for Co running
		private bool isCoR;
		private Controls userInput;


        private void Start()
        {
			userInput = new Controls();
        }


        // Allows the mines to be actived by mouse 0 for showcasing and testing.
        private void Update()
		{
			if ((userInput.MarbleMovementControls.UsePowerUp.phase == InputActionPhase.Performed) && DebugMine)
			{
				if ((RespawnMine) && (!isCoR))
				{
					StartCoroutine(MineRespawnDelay());
				}
				else
				{
					// Disables Mines Collision and mesh 
					GetComponent<MeshRenderer>().enabled = false;
					GetComponent<SphereCollider>().enabled = false;

					// Particles Play
					if (ExplosionParticles)
					{
						ExplosionParticles.Play();
					}

					if (SmokeParticles)
					{
						SmokeParticles.Play();
					}
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
				Debug.Log("Explosion Triggered");
				other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionPower, transform.position, ExplosionRadius, ExplosionUpwardPower, ForceMode.Impulse);

				if ((RespawnMine) && (!isCoR))
				{
					StartCoroutine(MineRespawnDelay());
				}
				else
				{
					// Disables Mines Collision and mesh 
					GetComponent<MeshRenderer>().enabled = false;
					GetComponent<SphereCollider>().enabled = false;

					// Particles Play
					if (ExplosionParticles)
					{
						ExplosionParticles.Play();
					}

					if (SmokeParticles)
					{
						SmokeParticles.Play();
					}
				}
			}
		}


		private IEnumerator MineRespawnDelay()
		{
			// Disables Mines Collision and mesh 
			isCoR = true;
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<SphereCollider>().enabled = false;
			// Particles Play
			if (ExplosionParticles)
			{
				ExplosionParticles.Play();
			}

			if (SmokeParticles)
			{
				SmokeParticles.Play();
			}
			yield return new WaitForSeconds(RespawnTime);
			// re-enables the mine is it respawns
			GetComponent<MeshRenderer>().enabled = true;
			GetComponent<SphereCollider>().enabled = true;
			isCoR = false;
		}
	}
}