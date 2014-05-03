using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		collision.rigidbody.AddForce(Vector3.up * 1000);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
