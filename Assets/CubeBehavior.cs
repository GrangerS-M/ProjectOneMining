using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour {

	public string cubeType;

	void OnMouseDown (){
		Destroy (gameObject);

		if (cubeType == "bronze"){
			GameController.score += 1;
			GameController.playerBronze -= 1;
		}
			
		if (cubeType == "silver") {
			GameController.score += 10;
			GameController.playerSilver -= 1;
		}

		if (cubeType == "gold") {
			GameController.score += 100;
			GameController.playerGold -= 1;
		}

		print ("score:" + GameController.score);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
