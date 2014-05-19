using UnityEngine;
using System.Collections;

public class CreateInventoryItem : MonoBehaviour {

	public GameObject inventoryItem;
	public Sprite grayscaleSprite;
	public bool isActive;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			
			if (this.collider2D == Physics2D.OverlapPoint(touch2D) && isActive)
			{
				spriteRenderer.sprite = grayscaleSprite;
				//isActive = false;

				inventoryItem.SetActive (true);
				inventoryItem.transform.position = transform.position;
				inventoryItem.transform.rotation = transform.rotation;

			}
		}
	}
}
