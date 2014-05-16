using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// Reset the rotation of this object
	public void resetRotation ()
	{
		this.transform.rotation = Quaternion.identity;
	}
}
