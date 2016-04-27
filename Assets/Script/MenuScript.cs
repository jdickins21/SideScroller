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
}
