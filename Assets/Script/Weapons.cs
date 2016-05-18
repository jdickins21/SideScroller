using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour 
{
	private GameObject player;
	public SpriteRenderer weapon;
	public bool pistol;
	public bool rifle;
	public bool shotgun;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		if (pistol)
			weapon = GameObject.FindGameObjectWithTag ("Pistol").GetComponent<SpriteRenderer>();
		if (rifle)
			weapon = GameObject.FindGameObjectWithTag ("Rifle").GetComponent<SpriteRenderer>();
		if (shotgun)
			weapon = GameObject.FindGameObjectWithTag ("Shotgun").GetComponent<SpriteRenderer>();

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{		
			player.GetComponent<WeaponControl> ().weapons.Add (weapon);

			StartCoroutine (wait1msec ());

		}
	}

	IEnumerator wait1msec()
	{
		yield return new WaitForSeconds (0.05f);
		Destroy (this.gameObject);
	}
}
