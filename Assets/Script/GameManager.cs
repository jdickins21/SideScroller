using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public int aliensHaveToKill;
	public int currentKilledAliens;
	public int tooManyAliens;
	public bool winner;

	public GameObject[] ground;

	public AudioClip levelSong;

	public MovieTexture openingVid;

	private static MovieTexture currVid;

	public EnemyManager enemy;
	public UserInput player;

	private AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		currVid = openingVid;
		StartCoroutine(playVid ());
	}

	public IEnumerator playVid(){
		if (currVid != null) {
			enemy.setCanSpawn (false);
			player.pauseNumOne ();
			audioSource.clip = currVid.audioClip;
			audioSource.loop = false;
			audioSource.clip = currVid.audioClip;
			audioSource.Play();
			currVid.Play ();
			yield return new WaitForSeconds(currVid.audioClip.length);
			audioSource.clip = levelSong;
			audioSource.loop = true;
			audioSource.Play ();
			enemy.setCanSpawn (true);
			player.pauseNumZero ();
		}
	}

	void OnGUI(){
		if (currVid != null && currVid.isPlaying) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), currVid);
		}
	}

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
			foreach(GameObject block in ground){
				Destroy (block);
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
