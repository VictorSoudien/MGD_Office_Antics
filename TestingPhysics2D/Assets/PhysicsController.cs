using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour {

	public Sprite stopButtonSprite;
	public GameObject ball;
	
	private Sprite playSprite;
	private SpriteRenderer spRender;
	private Vector3 initBallPosition;

	// Use this for initialization
	void Start () 
	{
		spRender = this.GetComponent<SpriteRenderer>();
		playSprite = spRender.sprite;
		initBallPosition = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire1"))
		{
			Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			
			if (this.collider2D == Physics2D.OverlapPoint(touch2D))
			{
				if (ball != null)
				{
					if (spRender.sprite.Equals(playSprite))
					{
						ball.rigidbody2D.isKinematic = false;
						spRender.sprite = stopButtonSprite;
					}
					else
					{
						
						ball.transform.position = initBallPosition;
						ball.transform.rotation = Quaternion.identity;
						ball.rigidbody2D.angularVelocity = 0;
						ball.rigidbody2D.velocity = Vector2.zero;
						ball.rigidbody2D.isKinematic = true;
						
						spRender.sprite = playSprite;
					}
				}	
			}
		}
	}
}
