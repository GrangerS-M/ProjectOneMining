using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	static public int playerBronze;
	static public int playerSilver;
	static public int playerGold;
	// This integer, "mineGold", will ensure that only one gold is made when the proper requirements are met.
	int mineGold;
	int bronzeSupply;
	int silverSupply;
	int miningSpeed;
	int timeToMine;
	public GameObject CubePreFab;
	GameObject currentCube;

	static public int score;

	Vector3 cubePosition;

	// Use this for initialization
	void Start () {
		playerBronze = 0;
		playerSilver = 0;
		playerGold = 0;
		miningSpeed = 2;
		// Both "silverSupply" an "bronzeSupply" have been removed from use, as they only made things more complicated at this point. They do still exist, however.
		mineGold = 1;
		timeToMine = miningSpeed;


	}

	// Update is called once per frame
	void Update () {
		if (Time.time > timeToMine) {

			if (playerBronze == 2 && playerSilver == 2 && mineGold == 1) {
				playerGold += 1;

				//Create gold.
				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject)Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer> ().material.color = Color.yellow;
				currentCube.GetComponent <CubeBehavior>().cubeType = "gold";

				mineGold = 0;
			}

			else if (playerBronze < 4) {
				playerBronze += 1;

				//Create silver.
				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject) Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer>(). material.color = Color.red;
				currentCube.GetComponent <CubeBehavior>().cubeType = "bronze";
				// This line's placement ensures that gold will be only made once each time the other requirements are met.
				mineGold = 1;
			}
			else if (playerBronze == 4) {
				silverSupply -= 1;
				playerSilver += 1;

				//Create bronze.
				cubePosition = new Vector3 (Random.Range (-4, 5), Random.Range (-4, 5), 0);
				currentCube = (GameObject) Instantiate (CubePreFab, cubePosition, Quaternion.identity);
				currentCube.GetComponent <Renderer>(). material.color = Color.white;
				currentCube.GetComponent <CubeBehavior>().cubeType = "silver";
				// This line's placement ensures that gold will be only made once each time the other requirements are met.
				mineGold = 1;
			}


			timeToMine += miningSpeed;
			// It was unclear in part 4 what was supposed to be done with this part of the code. I decided to keep it and add the player's gold to the printout.
			print ("Bronze: " + playerBronze + " ... Silver: " + playerSilver + " ... Gold: " + playerGold);
		}

	}
}