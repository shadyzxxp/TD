using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Hover : MonoBehaviour {

    SpriteRenderer spriterender;
    public GameObject thundertower;
    public GameObject firballtower;
    public GameObject icicletower;
    public GameObject[] buttons = new GameObject[6];
    GameObject tempbutton;
    bool overui = false;
    bool isempty = true;
    Vector3Int dep_cent;
    Ray ray;
    RaycastHit hit;
    int gold;
    int cost;

    // Use this for initialization
    void Start()
    {
        this.spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            isempty = false;
        }
        else
        {
            isempty = true;
        }

        Debug.Log(isempty);

        overui = EventSystem.current.IsPointerOverGameObject() ;

       //Debug.Log(overui);

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        gold= FindObjectOfType<GoldManager>().Gold;

        if (Input.GetMouseButtonDown(0))
        {
            deploy_tower();
        }
        switch (tempbutton.name)
        {
            case "Thunderbuttondisable":
                disablebutton(buttons[1]);
                disablebutton(buttons[2]);            
                break;
            case "fireballbuttondisable":
                disablebutton(buttons[0]);
                disablebutton(buttons[2]);              
                break;
            case "iciclebuttondisable":
                disablebutton(buttons[0]);
                disablebutton(buttons[1]);
                break;

        }

    }

    public void getbutton(GameObject button)
    {
        //Debug.Log("rereweweaa23");
        tempbutton = button;
        
    }

    public void deploy_tower()
    {
        //Debug.Log(tempbutton.name);

       if (overui==false&&isempty==true)
       { 
        switch (tempbutton.name)
        {
            case "Thunderbuttondisable":
                    //cost= FindObjectOfType<Thunder_Tower>().cost;
                    if (gold - 30 >= 0)
                  {
                     disablebutton(buttons[1]);
                     disablebutton(buttons[2]);
                     Instantiate(thundertower, transform.position, Quaternion.identity);
                     disablebutton(buttons[0]);
                     gameObject.SetActive(false);
                  }
                
                break;
            case "fireballbuttondisable":
                    //cost = FindObjectOfType<Fireball_Tower>().cost;
                    if (gold - 80 >= 0)
                    {
                        disablebutton(buttons[0]);
                        disablebutton(buttons[2]);
                        Instantiate(firballtower, transform.position, Quaternion.identity);
                        disablebutton(buttons[1]);
                        gameObject.SetActive(false);
                    }
                break;
            case "iciclebuttondisable":
                   // cost = FindObjectOfType<Thunder_Tower>().cost;
                    if (gold - cost >= 0)
                    {
                        disablebutton(buttons[0]);
                        disablebutton(buttons[1]);
                        Instantiate(icicletower, transform.position, Quaternion.identity);
                        disablebutton(buttons[2]);
                        gameObject.SetActive(false);
                    }
                break;

        }

      }
    }
    public void disablebutton(GameObject button)
    {
        button.SetActive(false);
    }
   /* void OnMouseOver()
    {
        Debug.Log("rereweweaa");
        if (Input.GetMouseButtonDown(0))
        {
            deploy_tower();
        }
        
    }*/
}
