using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class TeleportPipe : MonoBehaviour {

	public GameObject linkedPipe;
	public float exitVelocity;
	public List<GameObject> alternatePipes;
	public float changeTimer;
	
	public enum Type {NORMAL, FROST, TIMED};
	public Type pipeType;
	
	private float elapsedTime;
	private int currentLinkedPipe;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		currentLinkedPipe = 0;
		spriteRenderer = this.GetComponent<SpriteRenderer>();
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
					collision.transform.position = linkedPipe.transform.position;
					collision.rigidbody.AddForce(linkedPipe.transform.up * exitVelocity);
					GameController.playPipeWoosh();
				}
				else if (pipeType == Type.FROST)
				{
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
