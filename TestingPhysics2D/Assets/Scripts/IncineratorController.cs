using UnityEngine;
using System.Collections;

public class IncineratorController : MonoBehaviour {

	private bool ballCollided;
	
	// Use this for initialization
	void Start () 
	{
		ballCollided = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// Respond to a collision with the ball
	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector3 ballPosition = collision.transform.position;
		Vector3 pipePosition = this.transform.position;
		
		if ((Vector3.Distance(ballPosition, pipePosition) < 0.5f) && (ballCollided == false))
		{
			// Destroy Ball
			ballCollided = true;
		}
	}
}
