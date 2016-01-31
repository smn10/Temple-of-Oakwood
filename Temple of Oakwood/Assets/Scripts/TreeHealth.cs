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
		 // Set the score text.
		 textMesh.text = "Tree Health: " + tree.HP;
	}

}
