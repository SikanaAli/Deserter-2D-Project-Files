using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {

	public static int ammo;

	Text Ammunition;

	void Awake ()
	{
		// Set up the reference.
		Ammunition = GetComponent <Text> ();

		// Reset the score.
		ammo = 50;
	}
	// Update is called once per frame
	void Update () {
	
		Ammunition.text = "Ammo: " + ammo;
	}
}
