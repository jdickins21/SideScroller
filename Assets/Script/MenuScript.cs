using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	public void StartGame()
	{
		Application.LoadLevel (1);
	}
	public void Exit()
	{
		Application.Quit ();
	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void MainMenu()
	{
		Application.LoadLevel (0);
	}
}
