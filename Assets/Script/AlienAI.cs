using UnityEngine;
using System.Collections;

public class AlienAI : MonoBehaviour 
{
	public GameObject player;
	public float health;
	public GameObject explosion;
	public float speed;

	private GameManager gameManager;

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	void Update()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		//transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Instantiate (explosion, transform.position, Quaternion.identity);
			gameManager.currentKilledAliens++;
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
