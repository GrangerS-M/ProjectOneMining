using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4 : MonoBehaviour {

	int playerBronze;
	int playerSilver;
	int playerGold;
	// This integer, "mineGold", will ensure that only one gold is made when the proper requirements are met.
	int mineGold;
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
		playerGold = 0;
		miningSpeed = 3;
		// During part 4, it's possible that the way bronzeSupply works could be changed drastically, but I kept them the way it was before and changed it for the final part.
		// I did, however, remove silverSupply, as there was no longer a reason to have a limit on silver.
		bronzeSupply = 4;
		mineGold = 1;
		timeToMine = miningSpeed;


	}

	// Update is called once per frame
	void Update () {
		if (Time.time > timeToMine) {

			if (playerBronze == 2 && playerSilver == 2 && mineGold == 1) {
				playerGold += 1;

				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject)Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer> ().material.color = Color.yellow;

				mineGold = 0;
			}

			else if (bronzeSupply > 0) {
				bronzeSupply -= 1;
				playerBronze += 1;

				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject) Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer>(). material.color = Color.red;
				// This line's placement ensures that gold will be only made once each time the other requirements are met.
				mineGold = 1;
			}
			else if (bronzeSupply == 0 && silverSupply > 0) {
				silverSupply -= 1;
				playerSilver += 1;

				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject) Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer>(). material.color = Color.white;
				// This line's placement ensures that gold will be only made once each time the other requirements are met.
				mineGold = 1;
			}
		
				
			timeToMine += miningSpeed;
			// It was unclear in part 4 what was supposed to be done with this part of the code. I decided to keep it and add the player's gold to the printout.
			print ("Bronze: " + playerBronze + " ... Silver: " + playerSilver + " ... Gold: " + playerGold);
		}

	}
}