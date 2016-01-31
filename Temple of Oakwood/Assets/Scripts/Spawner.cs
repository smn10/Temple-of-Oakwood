using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	static int maxEnemyNum = 10;

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
		float height = Random.Range (-4.5f, 4f);
		return new Vector3 (-12.5f, height, -1f);
	}
}