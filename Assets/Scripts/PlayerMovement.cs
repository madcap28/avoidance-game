using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
	public Transform player;
    float forwardForce = 1000f;
    float sideForce = 25f;
	float difficulty;
    // Method that starts when Player starts moving
	// Reads from settings file to find difficulty.
	// Sets forwardForce based off difficulty.
    void Start()
    {
		string[] settings = File.ReadAllLines(@"settings.txt");
		difficulty = float.Parse(settings[0]);
		forwardForce = forwardForce + (250 * difficulty);
    }

    // Player Movement by adding force to the Rigidbody of the player.
	// If player's position falls below y = 0, then player has fallen off and lost the game.
    void FixedUpdate()
    {
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
		if (player.position.y < 0)
		{
			this.enabled = false;
			rigidBody.velocity = Vector3.zero;
		}
    }
}
