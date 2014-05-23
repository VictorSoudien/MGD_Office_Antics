using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class TeleportPipe : MonoBehaviour {

	public GameObject linkedPipe;
	public GameObject incineratorFlame;
	public float exitVelocity;
	public List<GameObject> alternatePipes;
	public float changeTimer;
	public PhysicsMaterial2D iceMaterial;
	
	public enum Type {NORMAL, FROST, TIMED, INCINERATOR};
	public Type pipeType;
	
	private float elapsedTime;
	private int currentLinkedPipe;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{	
		currentLinkedPipe = 0;
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		
		if (pipeType == Type.INCINERATOR)
		{
			incineratorFlame = GameObject.Find("IncineratorFlame");
			incineratorFlame.SetActive(false);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector3 ballPosition = collision.transform.position;
		Vector3 pipePosition = this.transform.position;
		
		if (Vector3.Distance(ballPosition, pipePosition) < 0.5f)
		{
			if (linkedPipe != null)
			{
				if (pipeType == Type.NORMAL)
				{
					GameController.playPipeEnter();
					collision.transform.position = linkedPipe.transform.position;
					collision.rigidbody.AddForce(linkedPipe.transform.up * exitVelocity);
				}
				else if (pipeType == Type.FROST)
				{
					collision.collider.collider2D.sharedMaterial = iceMaterial;
					collision.transform.position = linkedPipe.transform.position;
					collision.rigidbody.gravityScale = 2;
					collision.rigidbody.fixedAngle = true;
					GameController.playFreeze();
				}
				else if (pipeType == Type.TIMED)
				{
					//int pipeIndex = Mathf.Abs(currentLinkedPipe - 1) % alternatePipes.Count;
					collision.transform.position = alternatePipes[currentLinkedPipe].transform.position;
				}
			}
			if (pipeType == Type.INCINERATOR)
			{
				// Destroy the ball here
				GameController.playExplosion();
				GameObject explo = (GameObject) (Instantiate(incineratorFlame, incineratorFlame.transform.position, incineratorFlame.transform.rotation));
				explo.SetActive(true);
				
				// Display level end screen here
				//Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	void OnCollisionExit2D()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pipeType == Type.TIMED)
		{
			elapsedTime += Time.deltaTime;
			
			if (elapsedTime >= changeTimer)
			{
				elapsedTime = 0;
				currentLinkedPipe++;
				currentLinkedPipe %= alternatePipes.Count;
				spriteRenderer.sprite = alternatePipes[currentLinkedPipe].GetComponent<SpriteRenderer>().sprite;
			}
		}
	}
}
