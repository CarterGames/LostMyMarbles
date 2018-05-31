using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;

    private Rigidbody RB;

    // Use this for initialization
    void Start ()
    {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey("w"))
        {
            Move(MoveSpeed, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            Move(-MoveSpeed, 0, 0);
        }


        if (Input.GetKey("a"))
        {
            Move(0, 0, MoveSpeed);
        }
        if (Input.GetKey("d"))
        {
            Move(0, 0, -MoveSpeed);
        }
    }

    // Moving the marble around the scene
    void Move(float DirectionX, float DirectionY, float DirectionZ)
    {
        RB.AddTorque(DirectionX, DirectionY, DirectionZ);
    }

    void Slow()
    {
        RB.AddTorque(0, 0, 0);
    }
}
