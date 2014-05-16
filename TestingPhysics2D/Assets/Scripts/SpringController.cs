using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour 
{
	private bool hasBall;
	private GameObject ball;
	private Vector3 endPosition;
	private float ballMoveSpeed;

	// Use this for initialization
	void Start () 
	{
		hasBall = false;
		endPosition = this.transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject collidedObject = collision.gameObject;
		
		if (hasBall == false && collidedObject.name.Equals("Ball"))
		{		
			ball = collidedObject;
			ball.transform.rotation = Quaternion.identity;
			hasBall = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hasBall == true)
		{
			ball.rigidbody2D.isKinematic = true;
			ballMoveSpeed += Time.deltaTime;
			ball.transform.position = Vector3.Lerp(ball.transform.position, endPosition, ballMoveSpeed);
			
			if (ball.transform.position == this.transform.position)
			{
				endPosition	= this.transform.position + (this.transform.up * 1.1f);
			}
			else if (ball.transform.position == endPosition)
			{
				hasBall = false;
				ball.rigidbody2D.isKinematic = false;
				ball.rigidbody2D.AddForce(this.transform.up * 1300);
				ballMoveSpeed = 0;
				endPosition = this.transform.position;
			}
		}
	}
}
