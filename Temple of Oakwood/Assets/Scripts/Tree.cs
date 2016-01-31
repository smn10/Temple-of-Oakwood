using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public int HP;					

	// Use this for initialization
	void Start () {

	}

	public void Damage(int damage)
	{
		// Reduce the number of hit points by one.
		HP -= damage;
	}

	// Update is called once per frame
	void FixedUpdate () {

		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 /*&& !dead*/) {
			// ... call the death function.
			Application.Quit();
			Destroy(gameObject);
		}
	}
}
