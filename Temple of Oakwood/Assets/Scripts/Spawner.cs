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
	private int wraithCounter = 1;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	void Spawn ()
	{
		// Instantiate a random enemy.
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= maxEnemyNum &&
			wraithCounter % 10 != 0) {
			Instantiate (enemies [0], spawnPosition (), transform.rotation);
			wraithCounter++;
		}
		else if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= maxEnemyNum) {
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject gameObject in gameObjects) {
				if (gameObject.layer == 10) {
					return;
				}
			}
			Instantiate (enemies [1], spawnPosition (), transform.rotation);
			wraithCounter = 1;
		}
	}

	Vector3 spawnPosition() 
	{
		float height = Random.Range (lowerBoundary.transform.position.y, upperBoundary.transform.position.y);
			return new Vector3 (lowerBoundary.transform.position.x, height, -1f);
	}
}