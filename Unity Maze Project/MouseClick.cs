using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;



public class MouseClick : MonoBehaviour {
	//public StreamReader reader = null;
	public int i=0;
	public int L2 = 0;
	public int N2 = 0;
	public GameObject cubeDestoryAudio;
	public GameObject cubeHitAudio;
	public int K2 = 0;
	public int Kused=0;
	public int Antoxi=100;
	public float Score;
	//public String[] substrings;

	public ReadText2 readtext2;

	//edo tha valo posa sfiria exo "k" tha to paro orisma apo readtext
	//edo tha exo count=100 kai gia kathe ktipima count-10 kai an count==0 tote "k"="k"-1 
	// an k=0 tote teleiosan ta sfiria
	public int flag;
	public int flagtimes;
	//public int playsound;
	public GameObject Hammer;
	public GameObject RandHammer;
	public GameObject audio2;
	public float time;
	public GameObject LittleCube;
	public GameObject[] insta;
	public GameObject selector;


	public int x;

	// Use this for initialization
	void Start () {
		Kused = 0;
		time = 0;
		L2=ReadText2.L;
		N2=ReadText2.N;
		K2=ReadText2.K;

		print ("L2   "+L2);
		print ("N2   "+N2);
		print ("K2   "+K2);

		Score = N2 * N2 - time;
		flagtimes = 0;
	}

	// Update is called once per frame
	void Update () {
		if(time>=1){
			Score = Score - time; //;- Kused*50;
			time = 0;
		}
		//print ("Score iiiiissssssssss=:   " + Score);
		time = time + Time.deltaTime;    //edo ektipose ton xrono se sec pou pairnaei
		print ("Time: "+time + "|Score:  "+Score +"|Kused: "+Kused  + "|K2:  "+K2 +"|N2: "+N2);          //


		//if space is pressed play space sound
		//Delete = GameObject.Find ("Hammer").transform.position;
		Hammer = GameObject.Find ("Hammer");
		if (Input.GetMouseButtonUp(0)) {
			if(Kused<K2){//diladi exo sfiria na ktipiso
			print ("Right mouse click activated");

			Hammer = GameObject.Find ("Hammer");
		  	GetComponent<Animation>().Play("HammerNew");

			//Hammer = GameObject.Find ("Hammer");
			//GetComponent<Renderer> ().material.color = Color.white;//Color.green;
			//this.gameObject.GetComponent<Hammer>
				//gameObject.GetComponent<Renderer>().material.color = new Color(0,255,0);
				this.gameObject.GetComponent<Renderer>().material.color = new Color(0,255,0);

				if(flag==1){
						flagtimes = flagtimes + 1;
						Antoxi = Antoxi - 10;
						if(Antoxi==0){
							Kused = Kused + 1;
							Score=Score-50;
							Antoxi = 100;
						}						
						// Hit the cube and play the cube hit sound
						cubeHitAudio.GetComponent<AudioSource>().Play();
					}
			}
		} 
	}


	void OnTriggerEnter(Collider other){//collider and not other
			Debug.Log("Object Entered the trigger");
	}

	void OnTriggerStay(Collider other){
		Debug.Log("Object is within  trigger");
		flag = 1;

		if (flagtimes == 3) {
			Destroy (other.gameObject);
			cubeDestoryAudio.GetComponent<AudioSource>().Play();

			//Random rnd = new Random ();
			//int rndnumber = rnd.Next ();
			int rnd = new System.Random ().Next (4, 8);
			insta = new GameObject[rnd];
			for(i=0;i<rnd;i++){
				GameObject go = Instantiate(LittleCube, other.transform.position, Quaternion.identity);
				//insta[i]=(GameObject)Instantiate(LittleCube, other.transform.position, Quaternion.identity);
				insta[i] = go;
			}

			for(i=0;i<rnd;i++){
				Destroy (insta[i], 2.0f);		// Destory the  after 2 seconds
			}

			GameObject Tixeosfiri = Instantiate(RandHammer, transform.position, Quaternion.identity);
			Destroy (Tixeosfiri, 2.0f);

			flagtimes = 0;
		}
	}


	void OnCollisionEnter(Collision collision){
		ContactPoint contact = collision.contacts[0];
		//Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		//Instantiate (explosionPrefab, pos, new Vector3(pos.x,pos.y,pos.z));
		Destroy (collision.gameObject);
	}

	void OnTriggerExit(Collider other){
			Debug.Log("Object Exited the trigger");
			flag = 0;
		flagtimes = 0;
	}			


}
