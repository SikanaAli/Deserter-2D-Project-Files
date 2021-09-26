using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSyatem;
    public GameObject selectedObject;
    private bool buttonSelected;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)&& buttonSelected == false)
        {
            eventSyatem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }

		//if ()
	}

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
