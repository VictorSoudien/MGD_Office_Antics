using UnityEngine;
using System.Collections;

public class GameStartController : MonoBehaviour {

	private bool touched;
	
	// Use this for initialization
	void Start () 
	{
		touched = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)//Input.GetButtonDown("Fire1"))
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			
			if (this.collider2D == Physics2D.OverlapPoint(target))
			{
				touched = true;
			}
		}
		else if (Input.touchCount == 0)
		{
			if (touched == true)
			{
				Application.LoadLevel(1);
				touched = false;
			}
		}
	}
}
