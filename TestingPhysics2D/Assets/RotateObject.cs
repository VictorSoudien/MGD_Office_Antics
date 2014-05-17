using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour 
{
	private Vector2 previousTouch;
	public static GameObject selectedGameObject;

	private bool touched;

	// Use this for initialization
	void Start ()
	{
		previousTouch = Vector3.zero;
		touched = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire1") == true)
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);

			if (this.collider2D == Physics2D.OverlapPoint(touch2D) || (touched == true))
			{
				touched = true;
				float deltaX = touch2D.x - previousTouch.x;
				float deltaY = touch2D.y - previousTouch.y;

				Vector3 rot = this.transform.rotation.eulerAngles;
				Vector3 objectRotation = selectedGameObject.transform.rotation.eulerAngles;

				if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
				{
					if (touch2D.y < selectedGameObject.transform.position.y)
					{
						if (deltaX > 0)
						{
							rot.z += 1;
							objectRotation.z += 1;
						}
						else
						{
							rot.z -= 1;
							objectRotation.z -= 1;
						}
					}
					else
					{
						if (deltaX > 0)
						{
							rot.z -= 1;
							objectRotation.z -= 1;
						}
						else
						{
							rot.z += 1;
							objectRotation.z += 1;
						}
					}
				}
				else if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
				{
					if (touch2D.x > selectedGameObject.transform.position.x)
					{
						if (deltaY > 0)
						{
							rot.z += 1;
							objectRotation.z += 1;
						}
						else
						{
							rot.z -= 1;
							objectRotation.z -= 1;
						}
					}
					else
					{
						if (deltaY > 0)
						{
							rot.z -= 1;
							objectRotation.z -= 1;
						}
						else
						{
							rot.z += 1;
							objectRotation.z += 1;
						}
					}
				}

				this.transform.rotation = Quaternion.Euler(rot);

				if (selectedGameObject != null)
				{	
					selectedGameObject.transform.rotation = Quaternion.Euler(objectRotation);
				}

				previousTouch = touch2D;
			}
		}
		else
		{
			touched = false;
		}
	}
	
	// Reset the rotation of this object
	public void resetRotation ()
	{
		this.transform.rotation = Quaternion.identity;
	}
}
