using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public    Rigidbody2D arrow;			
	public 	  float       speed = 20f;				
	public    Animator    animator;
	public    string      animationTrigger;
	public    AudioClip   shootSound;


	private PlayerWalk playerCtrl;		// Reference to the PlayerControl script.


	void Awake()
	{
		// Setting up the references.
		animator = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerWalk>();
	}

	void Update () {
		if (PauseGame.isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}


	void FixedUpdate ()
	{
		// If the fire button is pressed...
		if(Input.GetButtonDown("Fire1"))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			//anim.SetTrigger("Shoot");
			//GetComponent<AudioSource>().Play();


			if (animator && !string.IsNullOrEmpty (animationTrigger)) {
				animator.SetTrigger (animationTrigger);
			}

			AudioSource.PlayClipAtPoint(shootSound, transform.position);

			// If the player is facing right...
			if(playerCtrl._facingRight)
			{
				float xpos = transform.position.x;
				xpos += 2.0f;
				Vector3 arrowPosition = new Vector3 (xpos, transform.position.y, transform.position.z);
				Rigidbody2D arrowInstance = Instantiate(arrow, arrowPosition, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				arrowInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				float xpos = transform.position.x;
				xpos -= 2.0f;
				Vector3 arrowPosition = new Vector3 (xpos, transform.position.y, transform.position.z);
				Rigidbody2D arrowInstance = Instantiate(arrow, arrowPosition, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				arrowInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}

}
