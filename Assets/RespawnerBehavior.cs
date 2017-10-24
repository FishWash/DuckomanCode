using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnerBehavior : MonoBehaviour {

	bool canReset = false;
	Canvas myCanvas;
	Text[] texts;

	// Use this for initialization
	void Start () {
		myCanvas = FindObjectOfType<Canvas>();
		texts = myCanvas.GetComponentsInChildren<Text>();
		texts[0].enabled = true;
		Invoke("CanReset", 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (canReset &&
			(Input.GetAxisRaw("Horizontal") != 0 ||
				Input.GetAxisRaw("Vertical") != 0 ||
				Input.GetAxisRaw("Jump") != 0))
		{
			//Application.LoadLevel(Application.loadedLevel);
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(sceneIndex);
		}
	}

	void CanReset ()
	{
		texts[1].enabled = true;
		canReset = true;
	}
}
