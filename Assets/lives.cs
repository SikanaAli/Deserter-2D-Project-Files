using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lives : MonoBehaviour {

	// Use this for initialization
	public static int NumLives;        // The player's score.


	Text life;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		life = GetComponent <Text> ();

		NumLives = 3;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		life.text =  "LIVES :"+ NumLives;
	}
}
