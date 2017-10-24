using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryBehavior : MonoBehaviour {

	Canvas myCanvas;
	Text[] texts;

	// Use this for initialization
	void Start () {
		myCanvas = FindObjectOfType<Canvas>();
		texts = myCanvas.GetComponentsInChildren<Text>();
		texts[2].enabled = true;
		Invoke("ShowThanks", 2);
	}

	void ShowThanks ()
	{
		texts[3].enabled = true;
	}
}
