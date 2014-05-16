using UnityEngine;
using System.Collections;

public class MoveByDragging : MonoBehaviour {

	public bool isMovable;

	private Animator animator;
	private bool selected;
	private GameObject selectionCircle;
	
	private BoxCollider2D touchCollider;
	private Collider2D physicsCollider;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator> ();
		selected = false;
		isMovable = true;

		selectionCircle = GameObject.Find ("SelectionCircle");
		touchCollider = this.GetComponentInChildren<BoxCollider2D>();
		physicsCollider = this.GetComponentInChildren<Collider2D>();
	}

	// Update is called once per frame
	void Update () 
	{
		physicsCollider.enabled = true;
		
		if (isMovable == true) 
		{
			if (Input.GetButton ("Fire1") == true) 
			{
				Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector2 touch2D = new Vector2 (target.x, target.y);

				/*if (selected == false) 
				{
					if (this.collider2D == Physics2D.OverlapPoint (touch2D)) 
					{
						animator.SetBool ("Touched", true);
						selected = true;
						this.transform.position = new Vector3 (target.x, target.y + 0.5f, 0);
					}
				} 
				else 
				{
					this.transform.position = new Vector3 (target.x, target.y + 0.5f, 0);

					// Draw the selection circle for the item
					if (selectionCircle != null)
					{
						selectionCircle.renderer.enabled = true;
					}
				}*/

				touchCollider.enabled = true;
					
				if ((touchCollider == Physics2D.OverlapPoint (touch2D)) || (physicsCollider == Physics2D.OverlapPoint (touch2D))) 
				{
					selected = true;
				}
				else
				{
					selected = false;
				}
			}
			/*else 
			{
				selected = false;
				animator.SetBool ("Touched", false);

				// Draw the selection circle for the item
				if (selectionCircle != null)
				{
					selectionCircle.renderer.enabled = false;
				}
			}*/
		}
		else
		{
			touchCollider.enabled = false;
			physicsCollider.enabled = true;
		}

		if (selectionCircle != null) 
		{
			if (selected == true)
			{
				selectionCircle.transform.position = this.transform.position;
				selectionCircle.renderer.enabled = true;
			}
			/*else
			{
				selectionCircle.renderer.enabled = false;
			}*/
		}
	}
}
