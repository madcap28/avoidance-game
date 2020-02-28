using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class RestartMenu : MonoBehaviour
{
	float sliderValue;
	
	// Restart Menu that is drawn when RestartMenu scene is loaded.
	// Only difference between this and Main Menu is Restart being the first choice.
	public void OnGUI()
	{
		GUI.BeginGroup(new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 800, 800));
		GUI.Box (new Rect (0, 0, 200, 200), "Menu");
		if (GUI.Button (new Rect (10, 30, 180, 30), "Restart?"))
		{
			string difficulty = sliderValue + "";
			File.WriteAllText(@"settings.txt", difficulty);
			Application.LoadLevel("GameScene");
		}
		GUI.Label(new Rect (10, 70, 180, 30), "          Difficulty Modifier");
		sliderValue = GUI.HorizontalSlider(new Rect(10, 90, 180, 30), sliderValue, -2, 2);
		GUI.Label(new Rect(10, 100, 180, 30), "Easy\tMedium\t      Hard");
		if (GUI.Button (new Rect (10, 120, 180, 30), "Leader Board"))
		{
			Application.LoadLevel("LeaderBoardScene");
		}
		if (GUI.Button (new Rect (10, 160, 180, 30), "Quit"))
		{
			Application.Quit();
		}
		GUI.EndGroup();
	}
}

