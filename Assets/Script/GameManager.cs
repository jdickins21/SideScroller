using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int aliensHaveToKill;
	public int currentKilledAliens;
	public int tooManyAliens;
	public bool winner;

	public GameObject[] ground;

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

		if (currentKilledAliens == tooManyAliens) 
		{
			int i = 0;
			while(ground[i] != null){
				Destroy (ground [i]);
				i++;
			}
		}
	}

	public static void pause(){
		Time.timeScale = 0;
	}

	public static void play(){
		Time.timeScale = 1;
	}
}
