using UnityEngine;
using System.Collections;

public class enemyDies : MonoBehaviour {

    // Use this for initialization
	private GameObject enemy;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag =="Missile")
		{
			enemy = GameObject.FindGameObjectWithTag ("Enemy");
			Destroy (enemy);


		}
	}
}
