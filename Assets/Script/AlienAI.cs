using UnityEngine;
using System.Collections;

public class AlienAI : MonoBehaviour 
{
	public GameObject player;
	public float health;
	public GameObject explosion;
	public float speed;
	public GameObject healthPrefab;
	public GameObject[] weaponPrefab;

	private GameManager gameManager;

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{

		transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Instantiate (explosion, transform.position, Quaternion.identity);
			gameManager.currentKilledAliens++;
			int r = Random.Range (0, 2);
			if (r == 1)
			{
				Instantiate (healthPrefab, transform.position, Quaternion.identity);
			}
			int r2 = Random.Range (0, 6);
			if (r2 == 3)
			{
				int r3 = Random.Range (0, weaponPrefab.Length +1);
				Instantiate (weaponPrefab[r3], transform.position, Quaternion.identity);
			}

			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Player") 
		{		
			player.GetComponent<UserInput> ().ApplyDamage (1);
		}
	}
}
