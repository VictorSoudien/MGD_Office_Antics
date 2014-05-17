using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class FanController : MonoBehaviour {

	public Vector2 windStrength;

	private List<Collider2D> objectsInZone;

	// Use this for initialization
	void Start () 
	{
		objectsInZone = new List<Collider2D> ();
	}

	void OnTriggerEnter2D(Collider2D collidedObject)
	{
		objectsInZone.Add (collidedObject);
	}

	void OnTriggerExit2D(Collider2D collidedObject)
	{
		objectsInZone.Remove (collidedObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		foreach (Collider2D coll in objectsInZone)
		{
			coll.rigidbody2D.AddForce(windStrength);
		}
	}
}
