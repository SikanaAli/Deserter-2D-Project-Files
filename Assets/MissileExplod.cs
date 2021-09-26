using UnityEngine;
using System.Collections;

public class MissileExplod : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Missile")
			Destroy (coll.gameObject, 0.7f);

	}

}
