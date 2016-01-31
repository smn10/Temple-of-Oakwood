using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float moveSpeed = 2f;
	public int HP = 2;					

	// Use this for initialization
	void Start () {

	}

	public void Damage()
	{
		// Reduce the number of hit points by one.
		HP--;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);	

		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 /*&& !dead*/)
			// ... call the death function.
			Destroy(gameObject);
	}
}