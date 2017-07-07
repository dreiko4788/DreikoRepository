using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Hit : MonoBehaviour {
	//public GameObject Obj;
	private Animator _Animator = null;
	// Use this for initialization
	void Start () {
		_Animator=GetComponent<Animator>();
		//anim = Obj.GetComponent<Animator> ();
	}

	//Animator anim;


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Debug.Log ("Pressed left click.");
		}
	}	
		//if(Input.GetMouseButton(0)){
			//Debug.Log ("Pressed left click.");
			//anim.Play("Animation3");
			void OnTriggerEnter(Collider collider){
				_Animator.SetBool("isAnimation3",true);
			}
		//}

		//if (Input.GetMouseButton(1))
			//Debug.Log("Pressed right click.");

		//if (Input.GetMouseButton(2))
			//Debug.Log("Pressed middle click.");
	//}
}
--------------------------------------------------------------------------
*/
public class AnimationHit : MonoBehaviour {
	Animator anim;

	public GameObject Obj;

	void start(){
		anim = Obj.GetComponent<Animator>();
	}

	void update(){
		if(Input.GetMouseButton(0)){
			Debug.Log ("Pressed LEft Click");
			print (":Mouse Is Pressed DudDdddddddddddd");
			anim.Play("<Animation3>");
		}
	}
}