using UnityEngine;
using System.Collections;

public class TreeHealth : MonoBehaviour
{
	public Tree tree;					
	private TextMesh textMesh;



	void Awake ()
	{	tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<Tree>();
		textMesh = GameObject.FindGameObjectWithTag("Tree Health").GetComponent<TextMesh>();
	}


	void Update ()
	{
		 textMesh.text = "Tree Health: " + tree.HP;

		if (PauseGame.isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

}
