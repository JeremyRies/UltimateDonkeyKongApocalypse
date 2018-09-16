using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daisy : MonoBehaviour {

    Rigidbody2D body;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

    public IEnumerator Charm()
    {
        body.velocity =  Vector2.down * speed;


    }
}
