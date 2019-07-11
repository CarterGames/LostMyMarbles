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

	// Check for Co running
	private bool IsCoRunning;



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
		}
	}


	private IEnumerator MineRespawnDelay()
	{
		IsCoRunning = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<SphereCollider>().enabled = false;
		yield return new WaitForSeconds(RespawnTime);
		GetComponent<MeshRenderer>().enabled = true;
		GetComponent<SphereCollider>().enabled = true;
		IsCoRunning = false;
	}
}
