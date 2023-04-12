using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class map : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject thundertower;
    public Vector3 gac(Vector3 cell)
    {
        return tilemap.WorldToCell(cell);
    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            deploy_tower();
        }
    }
    public void deploy_tower()
    {
        Debug.Log("rereweweaa2");
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(thundertower, transform.position, Quaternion.identity);
    }
    void OnMouseOver()
    {
        Debug.Log("rereweweaa");
        if (Input.GetMouseButtonDown(0))
        {
            deploy_tower();
        }

    }
}
