using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : Trap {

    public int howmanyhurt=0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(" coll name " + collider.gameObject.name);
        if (collider.gameObject.name == "knight(Clone)")
        {
            howmanyhurt++;
        }
    }
        // Use this for initialization
        void Start ()
    {
        dmg = 30;
        cost = 30;
	}

    

    // Update is called once per frame
    void Update ()
    {
        if(howmanyhurt>=3)
        {
            Destroy(gameObject);
        }
       
       
    }
}
