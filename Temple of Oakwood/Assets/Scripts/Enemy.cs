using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float moveSpeed = 2f;
	public int HP = 2;
	public int nemesisID;		
	public    Animator    animator;
	public    string      animationTrigger;

	private int count = 1;

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

	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Tree")
		{
			// ... find the Enemy script and call the Hurt function.

			// Call the explosion instantiation.
			//OnExplode();
			if (nemesisID == 0) {
				col.gameObject.GetComponent<Tree>().Damage(1);
				Destroy (gameObject);
				Debug.Log(col.gameObject.GetComponent<Tree>().HP);
			}

		}
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.tag == "Tree") {
			if (nemesisID == 1) {
				Debug.Log ("foo");
				if (count % 55 == 0) {
					col.gameObject.GetComponent<Tree> ().Damage (5);
				}
				if (animator && !string.IsNullOrEmpty (animationTrigger)) {
					animator.SetTrigger (animationTrigger);
				}
				count++;
			}
		}
	}
}