using UnityEngine;
using System.Collections;

public class TeleportPipe : MonoBehaviour {

	public GameObject linkedPipe;
	public float exitVelocity;

	// Use this for initialization
	void Start () 
	{
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector3 ballPosition = collision.transform.position;
		Vector3 pipePosition = this.transform.position;
		
		if (Vector3.Distance(ballPosition, pipePosition) < 0.5f)
		{
			if (linkedPipe != null)
			{
				collision.transform.position = linkedPipe.transform.position;
				collision.rigidbody.AddForce(linkedPipe.transform.up * exitVelocity);
			}
		}
	}
	
	void OnCollisionExit2D()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
