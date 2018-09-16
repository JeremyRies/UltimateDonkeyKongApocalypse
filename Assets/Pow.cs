﻿using System.Collections;
using System.Collections.Generic;
using Sound;
using UnityEngine;

public class Pow : MonoBehaviour {

    public BoxCollider2D Powbody;
    public Animator Powanim;

	// Use this for initialization
	void Start () {
        Powbody = GetComponent<BoxCollider2D>();

        StartCoroutine(POW());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator POW()
    {
	    SoundEffectService.Instance.PlayClip(ClipIdentifier.Pow);
        int state = 0;
        while (state==0)
        {
            yield return new WaitForSeconds(1);
            state = 1;
        }

        Powbody.enabled = true;

        
        while (state == 1)
        {
            yield return new WaitForSeconds(1);
            state = 2;
            Destroy(gameObject);
        }


    }
}
