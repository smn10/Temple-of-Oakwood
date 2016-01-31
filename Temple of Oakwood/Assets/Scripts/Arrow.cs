﻿using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	void Start () 
	{
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);
	}


	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		//Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		//Instantiate(explosion, transform.position, randomRotation);
	}

	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<Enemy>().Damage();

			// Call the explosion instantiation.
			OnExplode();

			Destroy (gameObject);
		}
		else if(col.gameObject.tag != "Player")
		{
			// Instantiate the explosion
			OnExplode();
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("hurtBoss");
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Enemy> ().Damage ();
			Destroy (gameObject);
		}
	}


}
