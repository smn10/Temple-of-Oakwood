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

	void Update () {
		if (PauseGame.isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Score.score > 100) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed * Score.score / 100, GetComponent<Rigidbody2D> ().velocity.y);	
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);	
		}

		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 /*&& !dead*/) {
			if (nemesisID == 0) {
				Score.score += 10;
			} else if (nemesisID == 1){
				Score.score += 50;
			}
			Destroy(gameObject);
		}
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