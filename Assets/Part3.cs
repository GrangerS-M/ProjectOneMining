using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3 : MonoBehaviour {

	int playerBronze;
	int playerSilver;
	int bronzeSupply;
	int silverSupply;
	int miningSpeed;
	int timeToMine;
	public GameObject CubePreFab;
	GameObject currentCube;

	Vector3 cubePosition;

	// Use this for initialization
	void Start () {
		playerBronze = 0;
		playerSilver = 0;
		miningSpeed = 3;
		bronzeSupply = 3;
		silverSupply = 2;
		timeToMine = miningSpeed;


	}

	// Update is called once per frame
	void Update () {
		if (Time.time > timeToMine) {
			if (bronzeSupply > 0) {
				bronzeSupply -= 1;
				playerBronze += 1;

				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject) Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer>(). material.color = Color.red;
			}
			else if (bronzeSupply == 0 && silverSupply > 0) {
				silverSupply -= 1;
				playerSilver += 1;

				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject) Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer>(). material.color = Color.white; 
			
			}
			timeToMine += miningSpeed;
			print ("Bronze: " + playerBronze + " ... Silver: " + playerSilver);
		}

	}
}