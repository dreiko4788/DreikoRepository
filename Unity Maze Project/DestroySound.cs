using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound : MonoBehaviour {
	public GameObject audio2;
	public int flag;
	public int flagtimes;
	public int playsound;
	public GameObject Hammer;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Hammer = GameObject.Find ("Hammer");
		if (Input.GetMouseButtonUp(0)) {
			Hammer = GameObject.Find ("Hammer");
			if(flag==1){
				flagtimes = flagtimes + 1;
				//play hit cube sound
				if(playsound == 1){
					audio2.GetComponent<AudioSource>().Play();
				}
			}
		} 
	}


	void OnTriggerStay(Collider other){
		Debug.Log("Object is within  trigger");
		flag = 1;
		if (flagtimes == 3) {
			//cube destroyed
			flagtimes = 0;
			playsound = 1;
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log("Object Exited the trigger");
		flag = 0;
		flagtimes = 0;
	}
}
