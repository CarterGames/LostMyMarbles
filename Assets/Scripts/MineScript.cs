using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
	[Header("Mine Properties")]
	[Tooltip("Amount of Power the explosion has...")]
	public float ExplosionPower = 50;
	[Tooltip("Radius the explosion has...")]
	public float ExplosionRadius = 50;
	[Tooltip("Amount of upward momentium the mine has...")]
	public float ExplosionUpwardPower = 35;


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
	private bool IsCoRunning;

	// Allows the mines to be actived by mouse 0 for showcasing and testing.
	private void Update()
	{
		if ((Input.GetMouseButtonDown(0)) && DebugMine)
		{
			if ((RespawnMine) && (!IsCoRunning))
			{
				StartCoroutine(MineRespawnDelay());
			}
			else
			{
				// Disables Mines Collision and mesh 
				GetComponent<MeshRenderer>().enabled = false;
				GetComponent<SphereCollider>().enabled = false;
				// Particles Play
				ExplosionParticles.Play();
				SmokeParticles.Play();
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Explosion Triggered");
			other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionPower, transform.position, ExplosionRadius, ExplosionUpwardPower, ForceMode.Impulse);

			if ((RespawnMine) && (!IsCoRunning))
			{
				StartCoroutine(MineRespawnDelay());
			}
			else
			{
				// Disables Mines Collision and mesh 
				GetComponent<MeshRenderer>().enabled = false;
				GetComponent<SphereCollider>().enabled = false;
				// Particles Play
				ExplosionParticles.Play();
				SmokeParticles.Play();
			}
		}
	}


	private IEnumerator MineRespawnDelay()
	{
		// Disables Mines Collision and mesh 
		IsCoRunning = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<SphereCollider>().enabled = false;
		// Particles Play
		ExplosionParticles.Play();
		SmokeParticles.Play();
		yield return new WaitForSeconds(RespawnTime);
		// re-enables the mine is it respawns
		GetComponent<MeshRenderer>().enabled = true;
		GetComponent<SphereCollider>().enabled = true;
		IsCoRunning = false;
	}
}
