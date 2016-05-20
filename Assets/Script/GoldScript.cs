﻿using UnityEngine;
using System.Collections;

public class GoldScript : MonoBehaviour {

	private int goldVal = 1;
	private GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{		
			player.GetComponent<UserInput> ().gainMoney (goldVal);

			Destroy (this.gameObject);
		}
	}
}