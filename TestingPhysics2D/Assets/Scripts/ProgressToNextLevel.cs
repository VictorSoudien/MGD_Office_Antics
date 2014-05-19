using UnityEngine;
using System.Collections;

public class ProgressToNextLevel : MonoBehaviour {

	public int indexOfNextScene = -1;

	private int callValue; // Ensures that coins are only added once

	// Use this for initialization
	void Start () 
	{
		GameController.initForLevel();
		callValue = 0;
	}
	
	// Detects a collision with another object
	void OnCollisionEnter2D(Collision2D collider)
	{
		if (indexOfNextScene != -1)
		{
			if (collider.gameObject.name.Equals("Ball"))
			{
				GameController.addCoinsToTotal(indexOfNextScene, callValue);
				callValue++;
			}
		}
	}
}
