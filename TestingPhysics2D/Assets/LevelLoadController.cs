using UnityEngine;
using System.Collections;

public class LevelLoadController : MonoBehaviour {

	public int levelIndex;
	
	private bool swiped;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () 
	{
		swiped = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
		{
			if (swiped == false)
			{
				swiped = true;
				targetPosition = this.transform.position;
				targetPosition.x -= 11.285f;
			}
			
			Vector2 deltaTouch = Input.GetTouch(0).deltaPosition;
			
			if (this.transform.position != targetPosition)
			{
				this.transform.Translate(deltaTouch.x * 0.1f, 0, 0f);
			}
		}
		else if (Input.touchCount == 0)
		{
			swiped = false;
		}
		else if (Input.touchCount == 1)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			
			if (this.collider2D.OverlapPoint(touch2D))
			{
				Application.LoadLevel(levelIndex);
			}
		}
	}
}
