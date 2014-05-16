using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour 
{
	public GameObject ball;
	public static bool resetCamera;
	
	private Vector3 cameraIntervalPositions;
	private int counter;

	// Use this for initialization
	void Start () 
	{
		cameraIntervalPositions = this.transform.position;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (resetCamera == true)
		{
			resetPosition();
		}
		if (ball != null)
		{
			if (ball.renderer.isVisible == false)
			{
		 		Vector3 newCameraPosition = this.transform.position;
		 		
		 		if (counter > 2)
		 		{
		 			newCameraPosition.x = newCameraPosition.x + 15;
		 		}
		 		cameraIntervalPositions = newCameraPosition;
				this.transform.position = cameraIntervalPositions;
		 		
		 		counter++;
		 	}
		 	else
		 	{
		 		this.transform.position = cameraIntervalPositions;
		 	}
		}
	}
	
	// Resets the position of the camera to the initial start position
	private void resetPosition()
	{
		this.transform.position = new Vector3(0,0,-10);
		cameraIntervalPositions = this.transform.position;
		counter = 0;
		resetCamera = false;
	}
}
