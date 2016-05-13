using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour 
{
	[Header("Input")]
	public float h;

	[Header("Player")]
	public float maxHealth = 5;
	public float curHealth = 5;
	public bool dead;
	public bool onGround;
	[Range(0,200)]
	public float jumpHeight;
	[Range(0,5)]
	public float characterSpeed = 2.5f;
	public int lookPosition = 1;

	[Header("Weapon")]
	public float maxRateOfFire = 1;
	public float rateOfFire = 1;
	public Transform bulletSpawnPoint;
	public LayerMask whatToHit;
	public GameObject bulletPrefab;

	public GameObject bulletSpawnPistol;
	public GameObject bulletSpawnShotgun;
	public GameObject bulletSpawnRifle;

	public GameObject bulletSpawn;

	private WeaponControl weaponControl;
	private Animator anim;
	private Rigidbody2D rigidbody2D;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		rateOfFire = maxRateOfFire;
		curHealth = maxHealth;
		weaponControl = GetComponent<WeaponControl> ();
	}

	void Update()
	{
		anim.SetFloat ("Speed", h);

		if (rateOfFire > 0) 
		{		
			rateOfFire -= Time.deltaTime;
		}

		if (Input.GetMouseButton(0) && rateOfFire < 0) 
		{
			anim.SetTrigger ("Shoot");
			rateOfFire = maxRateOfFire;
			GetComponent<AudioSource> ().Play();
			Shoot ();
		}

		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
			GetComponentInChildren<ArmRotation> ().rotationOffset = 180;
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
			GetComponentInChildren<ArmRotation> ().rotationOffset = 0;
		}

		if (rigidbody2D.velocity.y == 0) {
			onGround = true;
		} else {
			onGround = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && onGround)
		{
			rigidbody2D.AddForce (Vector2.up * 1000 * jumpHeight);
			anim.SetTrigger ("Jump");
		}

		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			GetComponent<WeaponControl> ().SwitchWeaponUp();
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			GetComponent<WeaponControl> ().SwitchWeaponDown();
		}

		if (weaponControl.weaponID == 0)
			bulletSpawn = bulletSpawnPistol;
		if (weaponControl.weaponID == 1)
			bulletSpawn = bulletSpawnShotgun;
		if (weaponControl.weaponID == 2)
			bulletSpawn = bulletSpawnRifle;
	}

	void FixedUpdate()
	{
		h = Input.GetAxis ("Horizontal");

		if (Input.GetAxis ("Horizontal") < -0.1f) 
			transform.Translate (Vector2.right * characterSpeed * h * Time.deltaTime);
		
		if (Input.GetAxis ("Horizontal") > -0.1f) 
			transform.Translate (Vector2.right * characterSpeed * h * Time.deltaTime);

	}

	void Shoot()
	{
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (bulletSpawnPoint.position.x, bulletSpawnPoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 2, whatToHit);
		Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition) * 2);

		Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

		if (hit.collider != null) 
		{
			if (hit.collider.gameObject.GetComponent<AlienAI> ()) 
			{
				hit.collider.gameObject.GetComponent<AlienAI> ().ApplyDamage (1);
			}
			if (hit.collider.gameObject.GetComponent<AlienBossAI> ()) 
			{
				hit.collider.gameObject.GetComponent<AlienBossAI> ().ApplyDamage (1);
			}
			if (hit.collider.gameObject.GetComponent<Rocket> ()) 
			{
				hit.collider.gameObject.GetComponent<Rocket> ().ApplyDamage (1);
			}

			Debug.DrawLine (firePointPosition, hit.point, Color.red);

		}
	}

	public void ApplyDamage(float damage)
	{
		curHealth -= damage;
		if (curHealth <= 0) 
		{
			anim.SetTrigger ("Dead");
			dead = true;
		}
	}
}
