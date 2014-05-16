using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {

	public Sprite stopButtonSprite;
	
	private Sprite playSprite;
	private SpriteRenderer spRender;

	// Use this for initialization
	void Start () 
	{
		spRender = this.GetComponent<SpriteRenderer>();
		playSprite = spRender.sprite;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			
			if (this.collider2D == Physics2D.OverlapPoint(touch2D))
			{
				if (spRender.sprite.Equals(playSprite))
				{
					GameController.runTrial();
					spRender.sprite = stopButtonSprite;
				}
				else
				{
					GameController.resetLevel();
					
					spRender.sprite = playSprite;
				}
			}
		}
	}
}
