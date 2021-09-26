using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showLives : MonoBehaviour {

	// Use this for initialization
	public static int LivesRemaining;        // The player's score.


	Text lifeRemaining;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		lifeRemaining = GetComponent <Text> ();

		LivesRemaining = lives.NumLives;
	}


	void Update ()
	{
		LivesRemaining = lives.NumLives;
		// Set the displayed text to be the word "Score" followed by the score value.
		if (LivesRemaining > 1) {
			lifeRemaining.text =  "You have "+ LivesRemaining +" lives to go";
		} else {
			lifeRemaining.text =  "You have "+ LivesRemaining +" life to go";
		}

	}
}
