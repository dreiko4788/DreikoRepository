using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class ReadText2 : MonoBehaviour {
	public GameObject cube1;
	public GameObject cube2;
	public GameObject cube3;
	public GameObject cubeT1;
	public GameObject cubeT2;
	public GameObject cubeT3;
	public GameObject FCube;
	public GameObject cyl;

	public GameObject myPlayer;
	public GameObject myCamera;
	public GameObject myCameraRotate;
	public GameObject Cylinder;

	public int playerPosX;
	public int playerPosZ;
	private Vector3 lastCamPos, tubePosition, playerPosition;

	public FileInfo theSourceFile = null;
	public StreamReader reader = null;
	public string text = " "; // assigned to allow first line to be read below
	public int lines = 0;
	public string[, ,] mazeGrid;
	public float speed = 5f;
	public static int L = 0;
	public static int N = 0;
	public static int K = 0;

	private int GAMEVIEW = 0;

	public int keyL = 0;
	public int keyN = 0;
	public int keyK = 0;

	public int i = 1;
	public int x = -5;
	public int y = 1;
	public int z = -5;
	public String[] substrings;
	public int rowCount = 0;
	public int colCount = 0;
	public int levelCount = -1;

		Vector3 GeneratedPosition() {
			return new Vector3(this.x ,this.y, this.z);			
		}

		void getRandPosition() {
			int emptyCount = 0;

			for (int i = 0; i < N; i++) {
				for (int k = 0; k < N; k++) {
					if (mazeGrid [i, 1, k] == "E") {
						emptyCount++;
					}
				}
			}
			//print ("Found " + emptyCount + "empty postion for the camera.");
			int rnd = new System.Random ().Next (1, emptyCount);
			//print ("Print:-> rnd "+rnd);

			int searchIndex = 0;
			for (int i = 0; i < N; i++) {
				for (int k = 0; k < N; k++) {
					if ( (mazeGrid[i, 1, k] == "E") ) {
						searchIndex = searchIndex + 1;
					}

					//print ("Search index is: " + searchIndex + "Rand is: " + rnd);
					if(searchIndex == rnd ) {
						playerPosX = i;
						playerPosZ = k;
					}
				}
			}
		}

		void parseInputFile() {
			// Read grid dimensions
			text = reader.ReadLine ();
			substrings = text.Split ('=');
			L = Int32.Parse (substrings [1]);

			text = reader.ReadLine ();
			substrings = text.Split ('=');
			N = Int32.Parse (substrings [1]);

			text = reader.ReadLine ();
			substrings = text.Split ('=');
			K = Int32.Parse(substrings[1]);

			// Create the grid
			print ("Creating a : "+N + ", " + L + ", " + N+ " grid array");
			mazeGrid = new string[N, L, N];

			while(true) {
				text = reader.ReadLine ();
				substrings = text.Split (' ');

				// If END was found break the while loop and end the parse
				if( substrings[0] == "END" ) {
					break;
				}

				// If we found LEVEL key then do this block of code else
				if( substrings[0] == "LEVEL") {
					//print("Level found");
					// Read a row that define the current LEVEL
					this.y = this.y + 1;
					this.rowCount = 0;
					//print ("LEVEL heres is: "+this.levelCount);
					this.levelCount = this.levelCount + 1;
					//print ("LEVEL heres is: "+this.levelCount);

				}else {
					// Read a row that define the cubes
					//print ("RGB found");
					foreach (var sb in substrings) {
						//print ("TOKEN: " + sb + "ROW: " + rowCount + "COL: " + colCount + "LEVEL " + this.levelCount);

						if (sb == "R") {
							//print ("Red found");
							mazeGrid[rowCount, levelCount, colCount] = "R";
							//Instantiate(cube2, GeneratedPosition(), Quaternion.identity);
							this.colCount++;
						} else if (sb == "G") {
							//print ("green found");
							mazeGrid[rowCount, levelCount, colCount] = "G";
							//Instantiate(cube1, GeneratedPosition(), Quaternion.identity);
							this.colCount++;
						} else if (sb == "B") {
							//print ("blue found");
							mazeGrid[rowCount, levelCount, colCount] = "B";
							//Instantiate(cube3, GeneratedPosition(), Quaternion.identity);
							this.colCount++;
						} else if (sb == "T1"){
							//print("Texture_1 found");
							mazeGrid[rowCount, levelCount, colCount] = "T1";
							//Instantiate(cubeT1, GeneratedPosition(), Quaternion.identity);
							this.colCount++;
						} else if (sb == "T2"){
							//print("Texture_2 found");
							mazeGrid[rowCount, levelCount, colCount] = "T2";
							//Instantiate(cubeT2, GeneratedPosition(), Quaternion.identity);
							this.colCount++;
						} else if (sb == "T3"){
							//print("Texture_3 found");
							mazeGrid[rowCount, levelCount, colCount] = "T3";
							//Instantiate(cubeT3, GeneratedPosition(), Quaternion.identity);
							this.colCount++;
						} else if (sb == "E"){
							//print("E(Empty) found");
							mazeGrid[rowCount, levelCount, colCount] = "E";
							this.colCount++;
						} else {
							//print ("Other found: " + sb);
						}

					}
					this.colCount = 0;
					this.rowCount = this.rowCount + 1;
				}
			}
			print("End of file is here! ");
		}

		void printMaze() {
			for (int i = 0; i < N; i++) {
				for (int j = 0; j < L; j++) {
					for (int k = 0; k < N; k++) {
						print (i+", "+j+", "+k+" >>"+mazeGrid[i, j, k]);
					}
				}
			}
			print ("Grid was printed OK");
		}

		void createCubes() {

			for (int i = 0; i < N; i++) {
				for (int j = 0; j < L; j++) {
					for (int k = 0; k < N; k++) {
						
						if(mazeGrid[i, j, k]== "R" ){
							Instantiate(cube3, new Vector3(i, j, k), Quaternion.identity);
						} else if(mazeGrid[i, j, k]==  "G" ){
							Instantiate(cube2,  new Vector3(i, j, k), Quaternion.identity);
						} else if(mazeGrid[i, j, k]==  "B" ){
							Instantiate(cube1,  new Vector3(i, j, k), Quaternion.identity);
						} else if(mazeGrid[i, j, k]==  "T1" ){
							Instantiate(cubeT1,  new Vector3(i, j, k), Quaternion.identity);
						} else if(mazeGrid[i, j, k]==  "T2" ){
							Instantiate(cubeT2,  new Vector3(i, j, k), Quaternion.identity);
						} else if(mazeGrid[i, j, k]== "T3"  ){
							Instantiate(cubeT3,  new Vector3(i, j, k), Quaternion.identity);
						} else if(mazeGrid[i, j, k]== "E"  ){
							
						} 

					}
				}
			}
		}

	void createFence () {
		for (int j = 0; j < L+2; j++) {
			for (int i = 0; i < N + 2; i++) {
				Instantiate (FCube, new Vector3 (i - 1, j, -1), Quaternion.identity);
				Instantiate (FCube, new Vector3 (i - 1, j, N), Quaternion.identity);

				Instantiate (FCube, new Vector3 (-1, j, i-1), Quaternion.identity);
				Instantiate (FCube, new Vector3 (N, j, i-1), Quaternion.identity);
			}
		}
	}

	void Start () {
		// Open a reader for the input file
		theSourceFile = new FileInfo ("C:\\Users\\S7venStars\\Desktop\\Grafika\\Unity\\maze.txt");
		reader = theSourceFile.OpenText();

		this.levelCount = -1;
		print ("Read the input file...");

		// Parse the input file and create a grid
		parseInputFile();
		print ("Printing the maze grid");
		// Prints the grid array - for defuggin purposes
		//printMaze ();

		// Create the cubes according to the maze array
		createCubes ();

		// Find a random position of an empty cube
		getRandPosition ();

		// Start of the game - Panoramic camera activated.
		myCameraRotate.SetActive (false);			// Deativate turnarround camera
		myPlayer.SetActive (false);					// Deactivate FPV camera
		myCamera.SetActive (true);					// Activate Panoramic camera
		lastCamPos = new Vector3 (playerPosX, 0, playerPosZ);

		// Create the cube that indicates the player position
		cyl = Instantiate(Cylinder, transform.position, Quaternion.identity);
		cyl.transform.position = lastCamPos;

		// Create an invisible fence that does not allow the player to go out of the maze
		createFence ();
	}

	void Update () {
		
		// Keyboard Interation
		if (Input.GetKeyDown (KeyCode.R)) {
			// R key was pressed - Activate Turnarround CAMERA
			myCamera.SetActive (false);						// Deactivate panoramic camera
			myCameraRotate.SetActive (true);				// Activate turnarround camera
			myPlayer.SetActive (false);						// Deactivate FPV camera
		} else if (Input.GetKeyDown (KeyCode.V)) {
			// V key was pressed - Activate FPV CAMERA
			if( GAMEVIEW == 0 ) {
				myCamera.SetActive (false);					// Deactivate panoramic camera
				myCameraRotate.SetActive (false);			// Deactivate turnarround camera

				myPlayer.SetActive (true);					// Activate FPV camera
				myPlayer.transform.position = lastCamPos;	// Set the first or last FPV camera position

				GAMEVIEW = 1;
			}else {
				// Update the tube position to the FPV camera' s current position
				lastCamPos = myPlayer.gameObject.transform.position;	// Get the last camera position
				cyl.transform.position = lastCamPos;			// Update the tube position

				myCameraRotate.SetActive (false);				// Deactivate panoramic camera
				myCamera.SetActive (true);						// Activate turnarround camera
				myPlayer.SetActive (false);						// Deactivate FPV camera
				
				GAMEVIEW = 0;
			}
		}
	}
}