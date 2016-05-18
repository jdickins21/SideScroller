using UnityEngine;
using System.Collections;

public class Valley : MonoBehaviour 
{
	public GameObject player;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{		
			player.GetComponent<UserInput> ().ApplyDamage (999);
			//Destroy (player);
		}
	}
}
