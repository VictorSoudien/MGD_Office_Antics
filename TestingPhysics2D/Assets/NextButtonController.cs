using UnityEngine;
using System.Collections;

public class NextButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Fire1") == true)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D =  new Vector2(target.x, target.y);

			if (this.collider2D == Physics2D.OverlapPoint(touch2D))
			{
				GameController.levelComplete();
			}
		}
	}
}
