using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 

{
	public bool right;
	public bool left;
	public GameObject player;
	public GameObject explosion;

	private float health = 1;
	private Rigidbody2D rigidbody2D;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidbody2D = GetComponent<Rigidbody2D> ();

		Destroy (this.gameObject, 15f);
	}

	void Update()
	{
		if(right)
			transform.Translate (transform.right * 1 * Time.deltaTime);

		if(left)
			transform.Translate (transform.right * - 1 * 1 * Time.deltaTime);	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("dead");
		if (other.gameObject.tag == "Player") 
		{		
			player.GetComponent<UserInput> ().ApplyDamage (1);
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;
		if (health <= 0) 
		{
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}

	}
}
