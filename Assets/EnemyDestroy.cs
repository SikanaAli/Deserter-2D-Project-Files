using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "Enemy"){
			Destroy (col.gameObject);
		}
	}
}
