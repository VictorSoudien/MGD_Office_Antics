using UnityEngine;
using System.Collections;

public class CreateInventoryItem : MonoBehaviour {

	public Sprite grayscaleSprite;
	public Sprite colourSprite;
	public GameObject inventoryItem;
	
	private SpriteRenderer spriteRenderer;
	private bool isActive;
	private bool isTouch;
	
	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = colourSprite;
		isActive = true;
		isTouch = false;
		inventoryItem.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.IsTrial == true) {
			spriteRenderer.sprite = grayscaleSprite;
		} else if (Input.GetButtonDown("Fire1") && isActive) {
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touch2D = new Vector2 (target.x, target.y);
			isTouch = true;

			// probably need to debounce this
			if (this.collider2D == Physics2D.OverlapPoint(touch2D)) {
				GameObject clone = (GameObject) Instantiate(inventoryItem, transform.position, transform.rotation);
				clone.SetActive(true);
				spriteRenderer.enabled = false;
				isActive = false;
			}
		} else {
			isTouch = false;
			spriteRenderer.sprite = colourSprite;
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (!isActive && !isTouch
		    && collision.gameObject.tag.Equals("PlacedInventory")
		    && collision.gameObject.name.Contains(inventoryItem.name)) {
			GameController.ItemSelected = false;
			MoveByDragging.selectionCircle.renderer.enabled = false;
			RotateObject.selectedGameObject = null;

			if (collision.gameObject.transform.parent) {
				Destroy(collision.gameObject.transform.parent.gameObject);
			} else {
				Destroy(collision.gameObject);
			}

			spriteRenderer.enabled = true;
			isActive = true;
		}
	}
}