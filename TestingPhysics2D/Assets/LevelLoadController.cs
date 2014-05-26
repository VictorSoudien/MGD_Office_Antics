using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class LevelLoadController : MonoBehaviour {

	public int levelIndex;
	
	public List<GameObject> listOfLevelSelectors;
	
	private bool swiped;
	private Vector3 targetPosition;
	
	float startTime;

	// Use this for initialization
	void Start () 
	{
		swiped = false;
		Vector3 newPosition = new Vector3(-0.2948666f, -0.07090187f, 0);
		
		foreach (GameObject gameObj in listOfLevelSelectors)
		{
			gameObj.transform.position = newPosition;
			newPosition.x += 11.285f;
		}
	}
	
	// Dsiplays the next level cover
	private void displayNext()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began))
		{
			startTime = Time.deltaTime;
		}
		else if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Ended))
		{
			startTime += Time.deltaTime;
			
			if (startTime < 0.05)
			{
				Vector2 touchLocation = new Vector2 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
				Vector2 origin = new Vector2 (this.transform.position.x, this.transform.position.y);
				
				RaycastHit2D hit = Physics2D.Raycast(this.transform.position, touchLocation);
				
				if (hit != null)
				{
					int levelIndex = listOfLevelSelectors.IndexOf(hit.collider.gameObject);
					
					if (levelIndex != -1)
					{
						Application.LoadLevel(levelIndex + 2);
					}
				}
			}
		}
		else if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
		{
			startTime += Time.deltaTime;
			if (swiped == false)
			{
				swiped = true;
				targetPosition = this.transform.position;
				targetPosition.x -= 11.285f;
			}
			
			Vector2 deltaTouch = Input.GetTouch(0).deltaPosition;
			
			if (this.transform.position != targetPosition)
			{
				this.transform.Translate(-deltaTouch.x * 0.1f, 0, 0f);
			}
		}
		else if (Input.touchCount == 0)
		{
			swiped = false;
		}
	}
}
