using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTwo : MonoBehaviour {

	int playerBronze;
	int playerSilver;
	int bronzeSupply;
	int silverSupply;
	int miningSpeed;
	int timeToMine;

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
			}
			else if (bronzeSupply == 0 && silverSupply > 0) {
				silverSupply -= 1;
				playerSilver += 1;
			}
			timeToMine += miningSpeed;
			print ("Bronze: " + playerBronze + " ... Silver: " + playerSilver);
		}
	
	}
}
