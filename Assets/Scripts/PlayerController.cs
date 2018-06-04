using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Movement Speed")]	
    public float MoveSpeed;					// Float for the speed of the Marble
    private Rigidbody RB;					// Getting the Rigidbody component from the Marble for later use


    // Start of Game
    void Start ()
    {

		// Setting up a variable "RB" for the rigidbody component
        RB = GetComponent<Rigidbody>();

	}
	

	// Every Frame
	void FixedUpdate ()
    {

		// Running the Movement function
		Move();

    }


	// Movement Function - to move the Marble using the riggidbody and adding force
	void Move()
	{
		// Gets the A,S,W,D inputs from the keyboard
		float moveHoz = Input.GetAxis("Horizontal");
		float moveVer = Input.GetAxis("Vertical");

		// Sets up the Vector3 for Movement using the inputted keyboard controls
		Vector3 Movement = new Vector3(moveHoz, 0.0f, moveVer);

		// Adds force to the Marble to make it move based on the Movement inputted Multiplied by the Movement Speed
		RB.AddForce(Movement * MoveSpeed);

	}


	// Slow Function - Yet to be written, will all the Marble to slow down once no inputs are recieved, e.g Drag
    void Slow()
    {

    }
}
