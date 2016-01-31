using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public int HP;		
	public GameObject endGame;
	public TextMesh endText;

	// Use this for initialization
	void Start () {
		endGame.SetActive (false);
		endText.text = "";
	}

	public void Damage(int damage)
	{
		// Reduce the number of hit points by one.
		HP -= damage;
	}

	void Update () {
		if (PauseGame.isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}

		if (Input.GetButtonUp("Restart")) {
			Debug.Log ("tried restart");
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		} else if (Input.GetButtonUp("Quit")) {
			Application.Quit();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 /*&& !dead*/) {
			// ... call the death function.
			HP = 0;
			PauseGame.isPaused = true;
			endGame.SetActive (true);
			endText.text = "Thanks for playing, your score is " + Score.score + "!\nPress 'R' to try again or press 'Q' to quit.\n\nCredits:\nSultan Nakyp, Dana Gregg, Sonalee Shah";
		}
	}
}
