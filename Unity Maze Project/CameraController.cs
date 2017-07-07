using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class CameraController : MonoBehaviour {
	public GameObject myPlayer;
	public GameObject myCamera;
	public GameObject myCameraRotate;

	// Use this for initialization
	void Start () {
		myCameraRotate.SetActive (false);			// Deativate turnarround camera
		myPlayer.SetActive (false);					// Deactivate FPV camera
		myCamera.SetActive (true);					// Activate Panoramic camera
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			// R key was pressed
			myCamera.SetActive (false);				// Deactivate panoramic camera
			myCameraRotate.SetActive (true);		// Activate turnarround camera
			myPlayer.SetActive(false);
		}else if( Input.GetKeyDown(KeyCode.V) ) {
			// V key was pressed
			print ("Deactivating Camera 1");
			myCamera.SetActive (false);				// Deactivating panoramic camera

			print ("Deactivating Camera 2");
			myCameraRotate.SetActive (false);		// Deactivate turnarround camera

			print ("Activating Camera 3 (FPV)");	// Activating FPV camera


			//string myS = myNM.getRandPosition ();
			//string[] myPos = myS.Split(':');
			//print (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

			//print (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

			//print (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

			//print (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			//print (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> \tCamera position is: " + myNM.playerPosX	+ " and " + myNM.playerPosZ);
			//myCamera.GetComponent

			//string posZ = myCamera.GetComponent ("playerPosZ");

			//myPlayer.SetActive(true);
			//myPlayer.transform.position = new Vector3 (posX, 0, posZ);
		}
	}
}