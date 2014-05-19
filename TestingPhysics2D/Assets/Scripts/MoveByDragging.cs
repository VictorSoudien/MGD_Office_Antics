using UnityEngine;
using System.Collections;

public class MoveByDragging : MonoBehaviour {

	public bool isMovable;

	private Animator animator;
	private bool selected;
	private GameObject selectionCircle;
	
	private BoxCollider2D touchCollider;
	private Collider2D physicsCollider;
	private Vector3 target;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator> ();
		selected = false;
		isMovable = true;
		target = Vector3.zero;
		
		selectionCircle = GameObject.Find ("SelectionCircle");
		
		// Due to the wind zone, fans need to be handled differently
		if (!this.name.Equals("Fan"))
		{
			touchCollider = this.GetComponentInChildren<BoxCollider2D>();
			physicsCollider = this.GetComponentInChildren<Collider2D>();
		}
		else
		{
			touchCollider = this.GetComponent<BoxCollider2D>();
			physicsCollider = touchCollider;	
		}
	}

	// Update is called once per frame
	void Update () 
	{
		physicsCollider.enabled = true;
		
		if (isMovable == true) 
		{
			if (Input.GetButton ("Fire1") == true)
			{
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector2 touch2D = new Vector2 (target.x, target.y);

				touchCollider.enabled = true;
				
				if (!selected && (GameController.ItemSelected == false))
				{
					if ((touchCollider == Physics2D.OverlapPoint (touch2D)) || (physicsCollider == Physics2D.OverlapPoint (touch2D))) 
					{
						selected = true;
						GameController.ItemSelected = true;
					}
					else
					{
						selected = false;
						GameController.ItemSelected = false;
					}
				}
			}
			else
			{
				selected = false;
				GameController.ItemSelected = false;
			}
		}
		else
		{
			touchCollider.enabled = false;
			physicsCollider.enabled = true;
		}

		
		if (selected == true)
		{
			this.transform.position = new Vector3 (target.x, target.y + 0.5f, 0);
		
			if (selectionCircle != null) 
			{
				selectionCircle.transform.position = this.transform.position;
				selectionCircle.renderer.enabled = true;
				RotateObject.selectedGameObject = this.gameObject;
			}
		}
	}
}
