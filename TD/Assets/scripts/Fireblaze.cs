using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireblaze : Trap {

   
	// Use this for initialization
	void Start ()
    {
        dmg = 10; //per sec
        cost = 30;
        duration = 5f;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
