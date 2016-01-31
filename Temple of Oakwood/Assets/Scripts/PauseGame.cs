using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	[HideInInspector]
	static public bool isPaused;
	public TextMesh pauseText;
	public GameObject startGame;

	// Use this for initialization
	void Start () {
		isPaused = true;
		pauseText.text = "";
		startGame.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Pause")) {
			if (!isPaused) {
				isPaused = true;
				pauseText.text = "The game is paused";
			} else {
				isPaused = false;
				pauseText.text = "";
			}
		}

		if (Input.GetButtonUp ("Submit")) {
			startGame.SetActive (false);
			isPaused = false;
			if (pauseText.text != "") {
				pauseText.text = "";
			}
		}
	}
}
