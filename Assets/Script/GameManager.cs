using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int aliensHaveToKill;
	public int currentKilledAliens;
	public bool winner;

	public void KilledAlien()
	{
		currentKilledAliens++;
	}

	void Update()
	{
		if (currentKilledAliens >= aliensHaveToKill) 
		{
			winner = true;
		}
	}

	public static void pause(){
		Time.timeScale = 0;
	}

	public static void play(){
		Time.timeScale = 1;
	}
}
