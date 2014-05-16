using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour 
{
	private Vector2 previousTouch;
	public static GameObject selectedGameObject;

	// Use this for initialization
	void Start ()
	{
		previousTouch = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire1") == true)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			if (this.collider2D == Physics2D.OverlapPoint(target))
			{
				Vector3 cirlcePos = (this.transform.position);
				
				target.x = target.x - cirlcePos.x;
				target.y = target.y - cirlcePos.y;
				
				float angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler(new Vector3(0,0,-angle));
				
				if (selectedGameObject != null)
				{	
					selectedGameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,-angle));
				}
			}
		}
	}
	
	// Reset the rotation of this object
	public void resetRotation ()
	{
		this.transform.rotation = Quaternion.identity;
	}
}
