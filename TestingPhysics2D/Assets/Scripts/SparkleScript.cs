using UnityEngine;
using System.Collections;

public class SparkleScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.activeSelf) {
		}
	}
}
