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
		[Header("Marble Controls")]
		[Tooltip("The speed that the marble will move at.")]
		[SerializeField] private float moveSpeed = 175f;
		[Range(0, 50)]
		[Tooltip("The height the marble can jump.")]
		[SerializeField] private float jumpHeight = 10f;
		[Tooltip("")]
		[SerializeField] private float fallSpeed = 3f;


		[SerializeField] private GameObject moveDirGO;



		private bool useCameraPoint = true;
		private bool isGrounded;
		private bool playerDead;
	    private bool canUsePowerup = true;
		private Controls userInput;
		private Vector3 _movement;
		private Rigidbody rb;
		private WaitForSeconds wait = new WaitForSeconds(1f);
		private GroundImpactParticles groundHitParticles;


		internal bool canUseControls;


		public PowerupOptions currentPowerUp;
		public PowerupOptions _currentPowerUp
        {
            get { return currentPowerUp; }
            set { currentPowerUp = value; }
        }


        #region Untiy Startup Methods
        /// <summary>
        /// Unity Method | Activates when the object is enabled
        /// </summary>
        private void OnEnable()
        {
			userInput.Enable();
        }

		/// <summary>
		/// Unity Method | Activates when the object is disabled
		/// </summary>
		private void OnDisable()
        {
			userInput.Disable();
			StopAllCoroutines();
        }

		/// <summary>
		/// Unity Method | Activates when the object is first started, ahead of the start method
		/// </summary>
		private void Awake()
        {
			userInput = new Controls();
        }

		/// <summary>
		/// Unity Method | Activates when the object is first started, after the awake method
		/// </summary>
		private void Start()
		{
			groundHitParticles = GetComponent<GroundImpactParticles>();

			//HideMouse();
			rb = GetComponent<Rigidbody>();

			canUseControls = true;
		}
        #endregion


        private void Update()
        {
			if (userInput.MarbleMovementControls.Jump.phase == InputActionPhase.Performed && isGrounded)
            {
                Debug.Log("Jump Pressed");
				GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                //Audio.PlayClip("Jump", Volume:.25f, Pitch: .5f);
                //Audio.PlayFromTime("Jump", .015f, .25f, .5f);
            }

			if (userInput.MarbleMovementControls.UsePowerUp.phase == InputActionPhase.Performed && canUsePowerup)
            {
				CallUseAbility();
            }


            if (playerDead)
			{
				ResetScene();
			}

			if (canUseControls)
			{
				_movement = new Vector3(userInput.MarbleMovementControls.Hoz.ReadValue<float>(), 0, userInput.MarbleMovementControls.Ver.ReadValue<float>());
			}
		}


        private void FixedUpdate()
		{
			if (canUseControls)
			{
				if (useCameraPoint)
				{
					_movement = moveDirGO.transform.TransformDirection(_movement);
				}

				GetComponent<Rigidbody>().AddForce(_movement * moveSpeed);
			}

			JumpSmoothing();

			isGrounded = IsInAir();

			if (isGrounded && !groundHitParticles.hasPlayedParticles)
            {
				groundHitParticles.SpawnImpactParticles();
				groundHitParticles.hasPlayedParticles = true;
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

		
		/// <summary>
		/// Checks to see if the player is in the air or not
		/// </summary>
		/// <returns></returns>
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
					groundHitParticles.hasPlayedParticles = false;
					return false;
				}
			}
			else
			{
				groundHitParticles.hasPlayedParticles = false;
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
					//Camera.main.GetComponentInParent<CameraController>().enabled = false;
					HideMouse();
					playerDead = true;
					break;
				case "Gem":
					Debug.Log("Gem Collected");
					other.gameObject.SetActive(false);
					break;
				case "Zomball":
					Debug.Log("Zomball Hit Player");
					GameObject.FindGameObjectWithTag("OutOfBounds").GetComponentInChildren<Text>().text = "A Zom-ball Ate You!";
					GameObject.FindGameObjectWithTag("OutOfBounds").GetComponentInChildren<Canvas>().enabled = true;
					Camera.main.transform.parent.LookAt(gameObject.transform);
					//Camera.main.GetComponentInParent<CameraController>().enabled = false;
					HideMouse();
					playerDead = true;
					break;
				default:
					break;
			}
		}



		private void CallUseAbility()
        {
            switch (currentPowerUp)
            {
                case PowerupOptions.None:
                    break;
                case PowerupOptions.MegaJump:

                    if (isGrounded)
                    {
                        MegaJump jump = new MegaJump();
                        jump.UseAbility(this.rb);

                    }

                    break;
                case PowerupOptions.Tracktion:
                    break;
                case PowerupOptions.Bouncy:
                    break;
                case PowerupOptions.SpeedBoost:

                    MegaSpeed speed = new MegaSpeed();
                    speed.UseAbility(this.rb);

                    break;
                case PowerupOptions.Shockwave:

                    MegaShockwave shock = new MegaShockwave();
                    shock.UseAbility(this.rb);

                    break;
                case PowerupOptions.Shield:

					MegaShield shield = new MegaShield();
					shield.UseAbility(this.rb);

					break;
                default:
                    break;
            }

			canUsePowerup = false;
			currentPowerUp = PowerupOptions.None;
			StartCoroutine(PowerUpCo());
		}


        private IEnumerator PowerUpCo()
        {
			yield return wait;
			canUsePowerup = true;
        }
    }
}