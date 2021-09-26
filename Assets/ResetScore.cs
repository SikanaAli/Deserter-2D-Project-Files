using UnityEngine;
using System.Collections;

public class ResetScore : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		if(PlayerPrefs.HasKey("playerScore")){
			PlayerPrefs.DeleteKey("playerScore");
		}
	}
}
