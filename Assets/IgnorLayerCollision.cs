using UnityEngine;
using System.Collections;

public class IgnorLayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision (4, 15);
	}
}
