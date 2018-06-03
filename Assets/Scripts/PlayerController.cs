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
	void FixedUpdate ()
    {
		Move();
    }

	void Move()
	{

		float moveHoz = Input.GetAxis("Horizontal");
		float moveVer = Input.GetAxis("Vertical");

		Vector3 Movement = new Vector3(moveHoz, 0.0f, moveVer);

		RB.AddForce(Movement * MoveSpeed);

	}

    void Slow()
    {

    }
}
