using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DDOL : MonoBehaviour
{
	// Preload scene method that occurs when game is started before main menu.
	// Creates the files needed to run the game: Leaderboard file and Settings file.
    void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if (!File.Exists(@"leaderboard.txt"))
		{
			File.Create(@"leaderboard.txt");
		}
		if (!File.Exists(@"settings.txt"))
		{
			File.Create(@"settings.txt");
		}
		Application.LoadLevel("MainMenuScene");
	}
}
