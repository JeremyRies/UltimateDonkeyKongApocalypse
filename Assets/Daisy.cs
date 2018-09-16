﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daisy : MonoBehaviour {

    Rigidbody2D body;
    public float speed;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(Charm());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

    public IEnumerator Charm()
    {
        body.velocity =  Vector2.down * speed;

        int state = 0;

        while (state == 0)
        {
            yield return true;
            if(Input.GetKey(KeyCode.Space))
            {
                speed = 0;
                body.velocity = Vector2.down * speed;
                state = 1;
            }
        }

        while (state == 1)
        {
            yield return new WaitForSeconds(5);
            state = 2;
            Destroy(gameObject);

        }

    }
}
