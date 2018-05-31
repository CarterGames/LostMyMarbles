using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Vector3 MoveDirection;

    private Vector3 Pos;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if (Input.GetKey("a"))
        {
            Move(MoveDirection.x, 0);
        }

	}

    // Moving the marble around the scene
    void Move(float DirectionX, float DirectionZ)
    {
        // Moves the player based on the inputted X & Z vaules, Doesn't allow jump movement on this function
        //transform.Translate(DirectionX * Time.deltaTime, MoveDirection.y, DirectionZ * Time.deltaTime);
        Pos = new Vector3(DirectionX * Time.deltaTime, MoveDirection.y, DirectionZ * Time.deltaTime);

        //transform.SetPositionAndRotation()
    }
}
