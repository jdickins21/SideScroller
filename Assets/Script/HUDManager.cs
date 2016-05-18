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
	public GameObject[] allEnemies;
	public int currLevel;
	public int nextLevel;

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
			allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < allEnemies.Length; i++) {
				Destroy (allEnemies [i]);
			}
			StartCoroutine (waitWinSecs());
		}

		if (player.GetComponent<UserInput> ().dead) 
		{
			loseText.SetActive (true);
			StartCoroutine (waitDeadSecs());
		}
	}

	IEnumerator waitWinSecs()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);
	}

	IEnumerator waitDeadSecs()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
