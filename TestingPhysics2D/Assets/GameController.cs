using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public Vector2 buttonPosition;

	private Vector3 initBallPosition;

	// Use this for initialization
	void Start () 
	{
		initBallPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Add a temp GUI to te game
	void OnGUI()
	{
		/*if (GUI.Button (new Rect (buttonPosition.x, buttonPosition.y, 80, 20), "Start")) 
		{
			//Application.LoadLevel(1);
			this.transform.position = initBallPosition;
			this.transform.rotation = Quaternion.identity;
			this.rigidbody2D.angularVelocity = 0;
			this.rigidbody2D.velocity = Vector2.zero;
			this.rigidbody2D.isKinematic = true;
		}*/
	}
}
