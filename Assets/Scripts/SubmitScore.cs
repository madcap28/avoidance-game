using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour
{
	public Transform player;
	public InputField iField;
	
	// Method that occurs when Submit button is pressed for submiting a new high score into the leaderboard.
	// Takes old leaderboard and creates a new one based on the positioning of the new high score to be added.
	// Writes to the leaderboard.txt file and loads the LeaderBoard scene afterwards.
    public void OnButtonPress()
	{
		int score = (int) player.position.z;
		string name = iField.text;
		string[] leaderBoard = File.ReadAllLines(@"leaderBoard.txt");
		int length = leaderBoard.Length;
		string[] newLeaderBoard;
		if (length == 10)
		{
			newLeaderBoard = new string[10];
		}
		else
		{
			newLeaderBoard = new string[length+1];
		}
		int position = CheckScores(score);
		int i = 0;
		int j = 0;
		do
		{
			if (i == position)
			{
				newLeaderBoard[i] = name + " " + score;
			}
			else
			{
				newLeaderBoard[i] = leaderBoard[j];
				j++;
			}
			i++;
		}
		while(i < length+1);
		string text = "";
		int k = 0;
		while (k < newLeaderBoard.Length)
		{
			if (k == (newLeaderBoard.Length - 1))
			{
				text = text + newLeaderBoard[k];
			}
			else
			{
				text = text + newLeaderBoard[k] + "\n";
			}
			k++;
		}
		File.WriteAllText(@"leaderBoard.txt", text);
		Application.LoadLevel("LeaderBoardScene");
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
