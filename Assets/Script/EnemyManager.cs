using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy; 
    public float spawnTime = 3f;  
    public Transform[] spawnPoints; 

	public GameManager gameManager;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
    }

	void Update()
	{
		if (gameManager.winner) {
			Destroy (this.gameObject);
		}
	}
    void Spawn ()
    {
		
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}