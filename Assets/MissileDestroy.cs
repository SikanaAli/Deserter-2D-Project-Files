using UnityEngine;
using System.Collections;

public class MissileDestroy : MonoBehaviour {


	[SerializeField]
	private AudioSource explosion;

	[SerializeField]
	private GameObject Missile;

	private int scoreUp = 10;

    // Use this for initialization
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {

			explosion.Play ();

			Missile.SetActive (true);

			ScoreManager.score += scoreUp;

			Destroy (coll.gameObject, 0.65f);
		}else if (coll.gameObject.tag == "barrels") {

			explosion.Play ();

			Missile.SetActive (true);
		}else if(coll.gameObject.tag == "Missile"){
			explosion.Play ();

			Missile.SetActive (true);

			Destroy (coll.gameObject, 0.65f);
		}else if (coll.gameObject.tag == "hide") {

			explosion.Play ();
			Missile.SetActive (true);
			Destroy (coll.gameObject, 0.5f);
			
		}
	}



}
