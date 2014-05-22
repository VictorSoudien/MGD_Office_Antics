using UnityEngine;
using System.Collections;

public class CollisionWithBall : MonoBehaviour {

	public GameObject sparkleObject;

	private Collider2D ballCollider;
	
	// Use this for initialization
	void Start () 
	{
		ballCollider = GameObject.FindGameObjectWithTag("Ball").collider2D;
		sparkleObject.SetActive (false);
	}
	
	// Checks if the ball has collided with it
	void OnTriggerEnter2D (Collider2D collidingObject)
	{
		if (collidingObject.Equals(ballCollider))
		{
			GameController.addTempCoin();
			this.gameObject.SetActive(false);

			// play sparkle for 0.5 seconds after coin is collected
			GameObject clone = (GameObject) Instantiate(sparkleObject, transform.position, transform.rotation);
			clone.SetActive(true);
			Destroy (clone, 0.5f);
		}
	}
}