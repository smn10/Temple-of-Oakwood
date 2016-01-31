using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.
	private TextMesh textMesh;



	void Awake ()
	{
		textMesh = GameObject.FindGameObjectWithTag("Booty").GetComponent<TextMesh>();
	}


	void Update ()
	{
		// Set the score text.
		 textMesh.text = "Score: " + score;
	}

}
