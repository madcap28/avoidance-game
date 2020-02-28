using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
	// The restart menu is opened when the continue button is pressed.
    public void OnButtonPress()
	{
		Application.LoadLevel("RestartMenuScene");
	}
}
