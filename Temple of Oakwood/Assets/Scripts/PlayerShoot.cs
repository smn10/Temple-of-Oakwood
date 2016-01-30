using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public    Rigidbody2D arrow;			
	public 	  float       speed = 20f;				
	public    Animator    animator;
	public    string      animationTrigger;


	private PlayerWalk playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.


	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerWalk>();
	}


	void Update ()
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

			// If the player is facing right...
			if(playerCtrl._facingRight)
			{
				Rigidbody2D arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				arrowInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				//Vector3 arrowPosition = new Vector3
				Rigidbody2D arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				arrowInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}

}
