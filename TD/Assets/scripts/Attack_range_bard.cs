using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_range_bard : MonoBehaviour {

    public GameObject mainbody;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(" coll name " + collider.gameObject.name);


        switch (collider.gameObject.name)
        {
            case "icewall":
                //mainbody.GetComponent<wizard>().enemy_hp=200;
                mainbody.GetComponent<Bard>().enemy_hp = 200;
                mainbody.GetComponent<Bard>().stop = true;
                mainbody.GetComponent<Bard>().Attack = true;
                break;
            case "Gate":
                mainbody.GetComponent<Bard>().enemy_hp = 200;
                mainbody.GetComponent<Bard>().stop = true;
                mainbody.GetComponent<Bard>().Attack = true;
                break;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
