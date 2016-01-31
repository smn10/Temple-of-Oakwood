using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public 	  Rigidbody2D _rigidBody;
	public 	  float 	  _jumpSpeed;
	public    Animator    _animator;
	public    string      _animationTrigger;
	public	  string 	  _jumpButton;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (PauseGame.isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	void FixedUpdate () {
		if (Input.GetButtonDown (_jumpButton) /*&& _rigidBody.velocity.y == 0.0f*/) 
		{
			Vector2 jumpForce = new Vector2 (0.0f, _jumpSpeed * Time.deltaTime);
			_rigidBody.AddForce (jumpForce);

			if (_animator && !string.IsNullOrEmpty (_animationTrigger)) {
				_animator.SetTrigger (_animationTrigger);
			}
		}
	}
}
