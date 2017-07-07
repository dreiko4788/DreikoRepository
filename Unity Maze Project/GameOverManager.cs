using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
	public GameObject myEG;
	public GUIText gameOverText;

	void Start() {
		myEG = GameObject.Find ("EndGame");
		gameOverText = myEG.GetComponent<GUIText> ();
	}


	void Update () {
		if( Input.GetKeyDown(KeyCode.X)) {
			print ("Displaying the text");
			gameOverText = myEG.GetComponent<GUIText> ();
			gameOverText.text = "Game Over";
			gameOverText.enabled = true;
		}
	}        
}
