using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
	public GameObject player;
	public GameManager gameManager;
	public Text killedCount;
	public Image health;
	public GameObject winnerText;
	public GameObject loseText;
	public GameObject pause;
	public GameObject[] allEnemies;
	public int currLevel;
	public int nextLevel;
	public GameObject nxtLvl;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	void Update()
	{
		killedCount.text = gameManager.currentKilledAliens + "/" + gameManager.aliensHaveToKill;
		health.fillAmount = player.GetComponent<UserInput> ().curHealth/player.GetComponent<UserInput> ().maxHealth;

		if (gameManager.winner) 
		{
			winnerText.SetActive (true);
			nxtLvl.SetActive (true);
			waitWinner ();
			winnerText.SetActive (false);
		}

		if (player.GetComponent<UserInput> ().dead) 
		{
			loseText.SetActive (true);
			allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < allEnemies.Length; i++) {
				Destroy (allEnemies [i]);
			}
		}
	}

	public void nextLvl()
	{
		SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);
	}

	public void pauseMen(){
		if(!pause.activeSelf){
			pause.SetActive (true);
			return;
		}
		pause.SetActive (false);
	}

	IEnumerator waitWinner()
	{
		yield return new WaitForSeconds (5f);
	}
}
