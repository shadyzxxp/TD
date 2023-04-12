using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderbolt : MonoBehaviour {

    // Use this for initialization
    public float time;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
