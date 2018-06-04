using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BottleFly : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Throw the bottle with a random force in a random rotation on the x axis
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Quaternion.Euler(0,0, Random.Range(110, 135)) * Vector3.right * Random.Range(10, 15), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
