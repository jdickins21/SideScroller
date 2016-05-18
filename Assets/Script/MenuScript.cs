using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}
	public void Exit()
	{
		Application.Quit ();
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	public static void EnterShop(){
		
		SceneManager.LoadScene (6, LoadSceneMode.Single);
	}

	public static void ExitShop(int curlevel){
		SceneManager.LoadScene (curlevel, LoadSceneMode.Single);
	}
}
