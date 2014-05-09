using UnityEngine;
using System.Collections;

public class ProgressToNextLevel : MonoBehaviour {

	public int indexOfNextScene = -1;

	// Use this for initialization
	void Start () 
	{
		GameController.initForLevel();
	}
	
	// Detects a collision with another object
	void OnCollisionEnter2D(Collision2D collider)
	{
		if (indexOfNextScene != -1)
		{
			if (collider.gameObject.name.Equals("Ball"))
			{
				Debug.Log (this.collider2D.name);
				GameController.addCoinsToTotal();			
				Application.LoadLevel(indexOfNextScene);
			}
		}
	}
}
