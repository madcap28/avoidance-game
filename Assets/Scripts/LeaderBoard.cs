using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LeaderBoard : MonoBehaviour
{
	string[] lines;
	
	// Read file when Leaderboard scene is loaded.
	void Start()
	{
		lines = File.ReadAllLines(@"leaderboard.txt");
	}
	
	// Draw leaderboard based off leaderboard file.
	void OnGUI()
	{
		int j = 0;
		string text = "";
		GUI.BeginGroup(new Rect(375, 0, 150, 800));
		GUI.Box(new Rect (0, 0, 150, 800), "Top 10 Hi-Scores");
		foreach (var line in lines)
		{
			text = (j+1) + " : " + line;
			GUI.Label(new Rect(10, 40*(j+1), 90, 120), text);
			j++;
		}
		GUI.EndGroup();
		GUI.BeginGroup(new Rect(500, 0, 200, 800));
		if (GUI.Button(new Rect(40, 80, 170, 30), "Back to Main Menu"))
		{
			Application.LoadLevel("MainMenuScene");
		}
		GUI.EndGroup();
	}

}
