using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {


	public  Text counterText;

	[SerializeField]
	private int plusIndex;

	public float seconds, minutes;

	private float coolDown = 10;

	private float cool;

	[SerializeField]
	private GameObject lvlComplete;

	void Awake(){
		if (ScoreManager.score == 0) {

			if (PlayerPrefs.HasKey ("playerScore")) {
				ScoreManager.score = PlayerPrefs.GetInt ("playerScore");
			} 
				
		} 
	}

	// Use this for initialization
	void Start (){
		counterText = GetComponent<Text>() as Text;
	
	}
	
	// Update is called once per frame
	void Update (){
		minutes = (int)(Time.timeSinceLevelLoad / 60f);
		seconds = (int)(Time.timeSinceLevelLoad % 60f);
		counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
		NextLevel ();
	}

	private void NextLevel(){

		if (minutes == 01 && seconds == 30) {

			pScore ();
			lvlComplete.SetActive (true);
			Time.timeScale = 0;

			coolDown -= Time.time;
			if (coolDown <= 0) {
				SceneManager.LoadScene (1 + plusIndex);
			}
				
	}

}
	private void pScore(){

		PlayerPrefs.SetInt ("playerScore", ScoreManager.score);
	}
}