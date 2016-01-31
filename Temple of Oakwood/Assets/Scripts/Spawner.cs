using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	static int maxEnemyNum = 10;
	public GameObject upperBoundary;
	public GameObject lowerBoundary;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	void Spawn ()
	{
		// Instantiate a random enemy.
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= maxEnemyNum) {
			int enemyIndex = Random.Range (0, enemies.Length);
			Instantiate (enemies [enemyIndex], spawnPosition (), transform.rotation);
		}
	}

	Vector3 spawnPosition() 
	{
		float height = Random.Range (lowerBoundary.transform.position.y, upperBoundary.transform.position.y);
		return new Vector3 (lowerBoundary.transform.position.x, height, -1f);
	}
}