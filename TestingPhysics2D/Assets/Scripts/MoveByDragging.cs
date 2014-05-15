using UnityEngine;
using System.Collections;

public class MoveByDragging : MonoBehaviour {

	private Animator animator;
	private bool selected;

	public bool isMovable;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator> ();
		selected = false;
		isMovable = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (isMovable == true) 
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
				animator.SetBool ("Touched", false);
			}
		}
		else
		{
			// Play sound here and vibrate phone
		}
	}
}
