﻿using UnityEngine;
using System.Collections;

public class AlienAI : MonoBehaviour 
{
	public GameObject player;
	public float health;
	public GameObject explosion;
	public float speed;

	private GameManager gameManager;
	private Vector2 target;

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}

	void Update()
	{
		target = new Vector2 (player.transform.position.x, player.transform.position.y);
		if (player.transform.position.y + .3f > transform.position.y) {
			transform.position = Vector2.MoveTowards (transform.position, (target + new Vector2(0, .7f)), speed * Time.deltaTime);
		} else if (player.transform.position.y - .3f < transform.position.y) {
			transform.position = Vector2.MoveTowards (transform.position, (target - new Vector2(0, .7f)), speed * Time.deltaTime);
		} else {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
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