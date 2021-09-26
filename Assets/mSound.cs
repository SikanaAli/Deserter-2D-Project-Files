using UnityEngine;
using System.Collections;

public class mSound : MonoBehaviour {

	public AudioSource rSound;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
			if (Ammo.ammo > 0) {
				if (Input.GetKeyDown (KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.Mouse0)) {
					rSound.Play ();

				}
			}
			
	}
}
