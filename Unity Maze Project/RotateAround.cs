using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
	
	private float speedMod = 2.0f;


	void Start () {
		//point = target.transform.position;
		Vector3 myV = new Vector3 (0, 0, 0);
		transform.LookAt(myV);



	}


	// Update is called once per frame
	void Update () {
		Vector3 myV = new Vector3 (7, 1, 7);
		transform.RotateAround (myV, new Vector3 (0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);

		if(Input.GetKey(KeyCode.V)){
			//print("V");
		}

		}

}
