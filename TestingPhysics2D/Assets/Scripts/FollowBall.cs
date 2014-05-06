using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour {

	public GameObject ball;
	
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
}
