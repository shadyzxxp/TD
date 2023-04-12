using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMist : Trap {

   
    // Use this for initialization
    void Start()
    {
        dmg = 5; //per sec
        cost = 20;
        duration = 5f;


    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
