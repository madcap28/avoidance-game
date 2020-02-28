using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public int lifeCount = 0;
    public PlayerMovement movement;
	
	// On Collision Method to determine what happens when colliding into an object.
	// If player collides into an obstacle and has a life count of 0 then the game is over.
	// If player collides into an obstacle and has a life count more than 0 then the player can keep going.
	// If player collides into a life then the life counter goes up by 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && lifeCount == 0)
        {
            movement.enabled = false;
        }
		if (collision.collider.tag == "Obstacle" && lifeCount > 0)
		{
			lifeCount--;
		}
		if (collision.collider.tag == "Life")
		{
			lifeCount++;
			GameObject life = FindClosest();
			Destroy(life);
		}
		
    }
	
	// FindClosest Method for finding closest life to destroy when colliding into one.
	public GameObject FindClosest()
	{
		GameObject[] lives = GameObject.FindGameObjectsWithTag("Life");
		GameObject closestLife = null;
		float distance = Mathf.Infinity;
		Vector3 position = movement.player.transform.position;
		foreach (GameObject life in lives)
		{
			Vector3 diff = life.transform.position - position;
			float currentDistance = diff.sqrMagnitude;
			if (currentDistance < distance)
			{
				closestLife = life;
				distance = currentDistance;
			}
		}
		return closestLife;
	}
}
