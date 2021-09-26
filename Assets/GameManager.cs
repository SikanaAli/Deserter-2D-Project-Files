using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject enemyPrefab;

	[SerializeField]
	private float timer;

	[SerializeField]
	private float delay;

	[SerializeField]
	private GameObject enemySpwaner;

	void Start () {


	}

	void Update(){

		timer -= Time.deltaTime;

		if (timer <= 0f) {

			GameObject enemy = Instantiate(enemyPrefab,enemySpwaner.transform.position,Quaternion.identity) as GameObject;
			timer = delay;
		}
			
	}
		

}

