using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE_Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        // explode and damage everything in a radius
    }
}
