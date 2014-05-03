using UnityEngine;
using System.Collections;

public class CollisionWithBall : MonoBehaviour {

	private Collider2D ballCollider;
	
	// Use this for initialization
	void Start () 
	{
		ballCollider = GameObject.FindGameObjectWithTag("Ball").collider2D;
	}
	
	// Checks if the ball has collided with it
	void OnTriggerEnter2D (Collider2D collidingObject)
	{
		if (collidingObject.Equals(ballCollider))
		{
			GameController.addTempCoin();
			this.gameObject.SetActive(false);
		}
	}
}