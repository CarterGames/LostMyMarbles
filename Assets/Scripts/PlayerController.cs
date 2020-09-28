using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CarterGames.Assets.AudioManager;
using UnityEngine.InputSystem;

namespace CarterGames.LostMyMarbles
{
	/// <summary>
	/// Class | Controls the player instances marble movement and respawning mechanics.
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		/// <summary>
		/// Controls the movespeed of the marble
		/// </summary>
		[SerializeField] private float moveSpeed = 175f;

		[Range(0, 50)]
		[SerializeField] private float jumpHeight = 10f;
		[SerializeField] private float fallSpeed = 3f;

		[Range(0, 15)]
		[SerializeField] private  float speedFalloff = 1f;
		[SerializeField] private  float speedReductionRate = .5f;
		[SerializeField] private float fallOffDelay = .1f;

		[SerializeField] private bool useCameraPoint = true;
		[SerializeField] private bool isGrounded;
		[SerializeField] private bool hasPlayedParticles = false;

		[SerializeField] private GameObject groundHitParticlesPrefab;
		private List<GameObject> groundHitParticlesPool;

		private GameObject moveDirGO;
		private Vector3 startPos;


		private Controls userInput;
		private Vector3 _movement;

		/// <summary>
		/// Controls whether or not the player need to respawn and is currently dead...
		/// </summary>
		private bool playerDead;

		private EndPadScript epScript;
		private AudioManager audioManager;


        private void OnEnable()
        {
			userInput.Enable();
        }


        private void OnDisable()
        {
			userInput.Disable();
        }


        private void Awake()
        {
			userInput = new Controls();
        }


        private void Start()
		{
			if (useCameraPoint) { moveDirGO = GameObject.FindGameObjectWithTag("CameraPoint"); }

			groundHitParticlesPool = new List<GameObject>();

            for (int i = 0; i < 3; i++)
            {
				GameObject _go = Instantiate(groundHitParticlesPrefab);
				groundHitParticlesPool.Add(_go);
            }

			//HideMouse();
			epScript = FindObjectOfType<EndPadScript>();
			audioManager = FindObjectOfType<AudioManager>();
		}


        private void Update()
        {
			if (userInput.MarbleMovementControls.Jump.phase == InputActionPhase.Performed && isGrounded)
            {
                Debug.Log("Jump Pressed");
				GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                //Audio.PlayClip("Jump", Volume:.25f, Pitch: .5f);
                //Audio.PlayFromTime("Jump", .015f, .25f, .5f);
            }


            if (playerDead)
			{
				ResetScene();
			}

			_movement = new Vector3(userInput.MarbleMovementControls.Hoz.ReadValue<float>(), 0, userInput.MarbleMovementControls.Ver.ReadValue<float>());
		}


        private void FixedUpdate()
		{
			if (useCameraPoint) 
			{ 
				_movement = moveDirGO.transform.TransformDirection(_movement); 
			}

			GetComponent<Rigidbody>().AddForce(_movement * moveSpeed);

			JumpSmoothing();

			isGrounded = IsInAir();

			if (isGrounded && !hasPlayedParticles)
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

				hasPlayedParticles = true;
			}
		}

		/// <summary>
		/// Smooths the jumping of the marble so it doesn't float in the air too much.
		/// </summary>
		private void JumpSmoothing()
		{
			GetComponent<Rigidbody>().AddForce(Vector3.up * Physics.gravity.y * (fallSpeed) * Time.deltaTime, ForceMode.VelocityChange);
		}


		/// <summary>
		/// Just toggles whether the mouse is visible in the game or not
		/// </summary>
		internal void HideMouse()
		{
			if (Cursor.lockState == CursorLockMode.None) 
			{ 
				Cursor.lockState = CursorLockMode.Locked; 
			}
			else 
			{ 
				Cursor.lockState = CursorLockMode.None; 
			}

			Cursor.visible = !Cursor.visible;
		}

		
		private bool IsInAir()
        {
			Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z), Color.green);
			RaycastHit hit;

			if (Physics.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z), out hit))
			{
				if (!hit.collider.gameObject.CompareTag("Player"))
				{
					return true;
				}
				else
				{
					hasPlayedParticles = false;
					return false;
				}
			}
			else
			{
				hasPlayedParticles = false;
				return false;
			}
        }


		/// <summary>
		/// Resets the game when the player dies
		/// </summary>
		private void ResetScene()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameObject.FindGameObjectWithTag("OutOfBounds").GetComponentInChildren<Animator>().SetBool("IsOFB", false);
				string ThisScene = SceneManager.GetActiveScene().name;
				Debug.Log(ThisScene);
				SceneManager.LoadSceneAsync(ThisScene);
				playerDead = false;
			}
			else
			{
				GameObject.FindGameObjectWithTag("OutOfBounds").GetComponentInChildren<Animator>().SetBool("IsOFB", true);
			}
		}


		private void OnTriggerEnter(Collider other)
		{
			// Does all the out of bounds stuff
			switch (other.gameObject.tag)
			{
				case "OutOfBounds":
					Debug.Log("Out Of Bounds");
					other.gameObject.GetComponentInChildren<Canvas>().enabled = true;
					Camera.main.transform.parent.LookAt(gameObject.transform);
					Camera.main.GetComponentInParent<CameraController>().enabled = false;
					HideMouse();
					playerDead = true;
					break;
				case "Gem":
					Debug.Log("Gem Collected");
					other.gameObject.SetActive(false);
					epScript.GemsCollected++;
					break;
				case "Zomball":
					Debug.Log("Zomball Hit Player");
					GameObject.FindGameObjectWithTag("OutOfBounds").GetComponentInChildren<Text>().text = "A Zom-ball Ate You!";
					GameObject.FindGameObjectWithTag("OutOfBounds").GetComponentInChildren<Canvas>().enabled = true;
					Camera.main.transform.parent.LookAt(gameObject.transform);
					Camera.main.GetComponentInParent<CameraController>().enabled = false;
					HideMouse();
					playerDead = true;
					break;
				default:
					break;
			}
		}
    }
}