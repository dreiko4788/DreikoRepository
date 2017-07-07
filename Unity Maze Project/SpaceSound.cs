using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSound : MonoBehaviour {
	public GameObject audio1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			
			audio1.GetComponent<AudioSource>().Play();
		}
	}
}
