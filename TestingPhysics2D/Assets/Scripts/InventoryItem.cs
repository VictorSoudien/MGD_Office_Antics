using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour {

	public Sprite grayscaleSprite;
	public Sprite colourSprite;
	public GameObject inventoryItem;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.IsTrial) {
			spriteRenderer.sprite = grayscaleSprite;
		} else if (Input.GetButtonDown("Fire1")) {
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			
			GameObject clone = (GameObject) Instantiate(inventoryItem, transform.position, transform.rotation);
			clone.SetActive(true);

			this.gameObject.SetActive(false);
			// check if inventory item hovers over it to replace it on the inventory

		} else {
			spriteRenderer.sprite = colourSprite;
		}
	}
}