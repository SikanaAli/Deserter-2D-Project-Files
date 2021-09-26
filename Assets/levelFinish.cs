using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelFinish : MonoBehaviour {


	private bool end = false;
	[SerializeField]
	private GameObject popUpText;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private int indexPlus;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){

		if (player.tag == "Player") {
			end = true;
			popUpText.SetActive(true);
		}
			
	}

	void OnTriggerExit2D(){

		if (player.tag == "Player") {
			end = false;
			popUpText.SetActive (false);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		lvlComp ();
	}


	private void lvlComp(){
		if((end == true) && (Input.GetKeyDown(KeyCode.E))){
			PlayerPrefs.SetInt ("playerScore", ScoreManager.score);
			SceneManager.LoadScene (2 + indexPlus);
		}
	}
}
