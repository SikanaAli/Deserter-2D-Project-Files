using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {


    public GameObject PauseUI;
    private bool paused = false;
	private float alinaswe = 3;
	[SerializeField]
	private GameObject GameOver;



    void start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;

        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }

    public void Resume()
    {
        paused = false;
    }
		

}
