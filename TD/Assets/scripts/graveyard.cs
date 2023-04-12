using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graveyard : Trap {

    public int howmanyhurt = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(" coll name " + collider.gameObject.name);
        if (collider.gameObject.name == "knight(Clone)")
        {
            howmanyhurt++;
        }
    }
    // Use this for initialization
    void Start()
    {
        dmg = 10;
        cost = 50;
    }



    // Update is called once per frame
    void Update()
    {
        if (howmanyhurt >= 12)
        {
            Destroy(gameObject);
        }


    }
}
