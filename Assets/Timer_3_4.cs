using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_3_4 : MonoBehaviour {






	public  Text counterText;

	public float seconds, minutes;

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
	}
		
			
			

}