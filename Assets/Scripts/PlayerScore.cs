using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerScore : MonoBehaviour
{
    public Transform player;
	public Text scoreText;
	public PlayerMovement movement;
	public Button rButton;
	public PlayerCollision collision;
	public InputField iField;
	public Button sButton;
	
	// Method that updates Score text box with score=z as the player moves.
	// If the player collides into something then this checks for movement.enabled = false to change Score text box.
	// If a new high score was obtained then a text field and submit button appear to enter into leaderboard.
	// Otherwise, continue button displays.
    void Update()
    {
		int score = (int) player.position.z;
        scoreText.text = score + "\nLives: " + collision.lifeCount;
		if (movement.enabled == false)
		{
			int newHigh = CheckScores(score);
			if (newHigh == -1)
			{
				scoreText.text = "Game Over\nFinal Score:" + score + "";
				rButton.transform.localScale = new Vector3(1, 1, 1);
			}
			else
			{
				scoreText.text = "Game Over\nFinal Score: " + score + "\nNew High Score!\nEnter Initials:";
				iField.transform.localScale = new Vector3(1, 1, 1);
				sButton.transform.localScale = new Vector3(1, 1, 1);
			}
		}
    }
	
	// CheckScores funtion takes in score of player to compare with Leaderboard.
	// Outputs position in leaderboard if the score can be added into leaderboard.
	// Otherwise returns -1 if it can't be placed into leaderboard.
	public int CheckScores(int score)
	{
		string[] leaderBoard = File.ReadAllLines(@"leaderboard.txt");
		int[] values = new int[10];
		if (leaderBoard.Length == 0)
		{
			return 0;
		}
		else
		{
			for(int i = 0; i < leaderBoard.Length; i++)
			{
				string[] text = leaderBoard[i].Split(' ');
				values[i] = Int32.Parse(text[1]);
			}
			int j = 0;
			foreach (var number in values)
			{
				if(score > number)
				{
					return j;
				}
				j++;
			}
			if (leaderBoard.Length < 10)
			{
				return j;
			}
		}
		return -1;
	}
}
