using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.LostMyMarbles
{
    public class GravityFlip : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private GameObject gravityOr;
        [SerializeField] private Vector3 newGravityDirection;
        [SerializeField] private bool canSwitchGravity;

        private GameObject marble;
        private Controls userInput;

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

        private void Update()
        {
            if (canSwitchGravity && userInput.MarbleMovementControls.UsePowerUp.phase == InputActionPhase.Performed)
            {
                marble.GetComponent<ConstantForce>().force = newGravityDirection;
                GameObject.FindGameObjectWithTag("CameraPoint").transform.rotation = Quaternion.Euler(-90, 0, 0);
                gravityOr.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            canSwitchGravity = true;
            
            if (other.gameObject.CompareTag("Player"))
            {
                marble = other.gameObject;
            }    
        }


        private void OnTriggerExit(Collider other)
        {
            canSwitchGravity = false;
        }
    }
}