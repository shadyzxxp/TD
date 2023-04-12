using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icewall : Tower
{
    
 
    /*void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(" colli name " + collider.gameObject.name);
        if (collider.gameObject.name == "swordslash(Clone)")
        {
            hp -= 15;
        }

    }*/
   
        // Use this for initialization
        void Start ()
    {
        hp = 200;
        dmg = 0;
        cost = 30;
        level = 1;
        tower_name = "ice wall";
        cd = 10f;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(" wall hp " + hp);
        if(hp<=0)
        {
            Destroy(gameObject);
        }
	}
}
