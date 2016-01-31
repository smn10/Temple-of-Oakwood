using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	[HideInInspector]
	static public bool isPaused = true;
	public TextMesh pauseText;
	public TextMesh startText;

	// Use this for initialization
	void Start () {
		pauseText.text = "";
		startText.text = "Start game?";
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
			startText.text = "";
			isPaused = false;
			if (pauseText.text != "") {
				pauseText.text = "";
			}
		}
	}
}
