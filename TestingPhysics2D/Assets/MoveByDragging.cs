using UnityEngine;
using System.Collections;

public class MoveByDragging : MonoBehaviour {

	private Animator animator;
	private bool selected;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator> ();
		selected = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Fire1") == true) 
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);

			if (selected == false)
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
			}
		}
		else
		{
			selected = false;
			animator.SetBool("Touched", false);
		}

		/*
		if (Input.touchCount == 1) 
		{
			Vector3 touch3D = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touch2D = new Vector2(touch3D.x, touch3D.y);

			if (this.collider2D == Physics2D.OverlapPoint(touch2D))
			{
				//this.transform.position = touch2D;
				animator.SetBool("Touched", true);
			}
		}*/
	}
}
