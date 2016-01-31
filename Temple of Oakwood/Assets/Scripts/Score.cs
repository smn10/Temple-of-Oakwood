using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	static public int score;					// The player's score.
	private TextMesh textMesh;



	void Awake ()
	{
		textMesh = GameObject.FindGameObjectWithTag("Booty").GetComponent<TextMesh>();
		score = 0;
	}


	void Update ()
	{
		// Set the score text.
		textMesh.text = "Score: " + score;

		if (PauseGame.isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

}
