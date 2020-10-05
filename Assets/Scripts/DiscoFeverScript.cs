using CarterGames.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


namespace CarterGames.LostMyMarbles
{
	public class DiscoFeverScript : MonoBehaviour
	{
        [Header("Marbles To Effect")]
        [Tooltip("All marbles on the floor that should be effected.")]
        [SerializeField] private List<GameObject> _marbles;

        [Header("Disco Floor Controls")]
        [Tooltip("The colours that the floor can change too.")]
		[SerializeField] private Color[] _colours;

        [Tooltip("The floor planes to are needed.")]
		[SerializeField] private GameObject[] _floorPieces;

        [Tooltip("The time between each colour change.")]
        [SerializeField] private float timeDelay;

        private WaitForSeconds _floorDelay;
        private Material[] _floorMats;
        private bool isCoR;
        private bool isMarbleCoR;


        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Start()
        {
            _floorDelay = new WaitForSeconds(timeDelay);
            _marbles = new List<GameObject>();
            _floorMats = new Material[_floorPieces.Length];

            for (int i = 0; i < _floorPieces.Length; i++)
            {
                _floorMats[i] = _floorPieces[i].GetComponent<Renderer>().material;
            }

            isCoR = false;
        }


        private void Update()
        {
            if (_marbles.Count > 0 && !isMarbleCoR)
            {
                StartCoroutine(RandomMarbleMovementCo());
            }

            ChangeFloorColour();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!_marbles.Contains(other.gameObject) && other.GetComponent<PlayerController>())
            {
                AddToMarbles(other.gameObject);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                RemoveFromMarbles(other.gameObject);
            }
        }


        private void AddToMarbles(GameObject _newObj)
        {
            _marbles.Add(_newObj);
        }


        private void RemoveFromMarbles(GameObject _newObj)
        {
            _marbles.Remove(_newObj);
        }


        private void ChangeFloorColour()
        {
            if (!isCoR)
            {
                StartCoroutine(ColourChangeCo());
            }
        }


        private IEnumerator ColourChangeCo()
        {
            isCoR = true;

            for (int i = 0; i < _floorMats.Length; i++)
            {
                _floorMats[i].color = _colours[Random.Range(0, _colours.Length)];
            }

            yield return _floorDelay;

            isCoR = false;
        }


        private IEnumerator RandomMarbleMovementCo()
        {
            isMarbleCoR = true;

            for (int i = 0; i < _marbles.Count; i++)
            {
                _marbles[i].GetComponent<Rigidbody>().AddForce(GetRandom.Vector3(-15f, 15f), ForceMode.VelocityChange);
            }

            yield return _floorDelay;

            isMarbleCoR = false;
        }
    }
}