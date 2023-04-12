using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kknight : soldier
{
    public int arrowblock;
    int mynum;
    GameObject[] spawnpoint = new GameObject[3];
    GameObject[] waypoint = new GameObject[3];
    Vector3[] destnation = new Vector3[3];
    Vector3[] pos = new Vector3[3];
    Vector3Int[] centerpos = new Vector3Int[3];
    Vector3Int[] wp = new Vector3Int[3];
    char keydown = 'i';
    bool isidle = true;
    bool stop = false;
    bool Attack = false;
    int wp_in_progress = 0;
    int enemy_hp = 200;
    public float panSpeed = 1f;
    float attack_cast_time = 1f;
    float attack_cd_time = 2f;
    string enemyname;
    string[] effectorname = new string[5];
    public Vector3 attackpos;
    public LayerMask whatisenemy;
    public float attack_range = 0.5f;
    public float movement_delay = 1f;
    public float damaged_state_persec = 0f;
    public float spikecd = 0f;
    public int burnt = 0;
    public int poisoned = 0;
    public int spiked = 0;
    public int haunted = 0;
    bool Barrieron = false;
    int effectorcounter = 0;
    bool isthereEffect = false;



    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(" coll name " + collider.gameObject.name);
        
     
        switch (collider.gameObject.name)
        {
            case "arrow":
                if (arrowblock > 0)
                {
                    //trigger shield dmg  anim
                    arrowblock -= 1;
                }
                break;
            case "icewall":
                enemy_hp = 200;
                stop = true;
                Attack = true;
                break;
            case "Gate":
                enemy_hp = 200;
                stop = true;
                Attack = true;
                break;
            case "Fireblaze(Clone)":
                condition = "OnFire";
                break;
            case "PoisonMist(Clone)":
                condition = "poisoned";
                break;
            case "pitfall1uncovered":
                condition = "spiked";
                break;
            case "graveyard":
                condition = "haunted";
                Debug.Log("haun");
                break;
                //default:
        }
    }
     

    // Use this for initialization
    void Start()
    {

        hp = 200;
        dmg = 15;
        bounty = 60;
        arrowblock = 5;
        mynum = FindObjectOfType<wave_class>().assign_knight();
        spawnpoint[0] = GameObject.Find("spawn point1");

        spawnpoint[1] = GameObject.Find("spawn point2");

        spawnpoint[2] = GameObject.Find("spawn point3");

        Vector3 charpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Vector3Int cellcenterpos = FindObjectOfType<wave_class>().get_cent(charpos);

        pos[0] = new Vector3(spawnpoint[0].transform.position.x, spawnpoint[0].transform.position.y, spawnpoint[0].transform.position.z);
        centerpos[0] = FindObjectOfType<wave_class>().get_cent(pos[0]);

        pos[1] = new Vector3(spawnpoint[1].transform.position.x, spawnpoint[1].transform.position.y, spawnpoint[1].transform.position.z);
        centerpos[1] = FindObjectOfType<wave_class>().get_cent(pos[1]);

        pos[2] = new Vector3(spawnpoint[2].transform.position.x, spawnpoint[2].transform.position.y, spawnpoint[2].transform.position.z);
        centerpos[2] = FindObjectOfType<wave_class>().get_cent(pos[2]);



        if (cellcenterpos.x == centerpos[0].x)
        {
            line = 1;
            waypoint[0] = GameObject.Find("First Line Waypoint1");
            waypoint[1] = GameObject.Find("First Line Waypoint2");
            waypoint[2] = GameObject.Find("First Line Waypoint3");
        }
        else if (cellcenterpos.x == centerpos[1].x)
        {
            line = 2;
            waypoint[0] = GameObject.Find("Second Line Waypoint1");
            waypoint[1] = GameObject.Find("Second Line Waypoint2");
            waypoint[2] = GameObject.Find("Second Line Waypoint3");
        }
        else
        {
            line = 3;
            waypoint[0] = GameObject.Find("Third Line Waypoint1");
            waypoint[1] = GameObject.Find("Third Line Waypoint2");
            waypoint[2] = GameObject.Find("Third Line Waypoint3");
        }

        destnation[0] = new Vector3(waypoint[0].transform.position.x, waypoint[0].transform.position.y, waypoint[0].transform.position.z);
        wp[0] = FindObjectOfType<wave_class>().get_cent(destnation[0]);

        destnation[1] = new Vector3(waypoint[1].transform.position.x, waypoint[1].transform.position.y, waypoint[1].transform.position.z);
        wp[1] = FindObjectOfType<wave_class>().get_cent(destnation[1]);

        destnation[2] = new Vector3(waypoint[2].transform.position.x, waypoint[2].transform.position.y, waypoint[2].transform.position.z);
        wp[2] = FindObjectOfType<wave_class>().get_cent(destnation[2]);

     
    }
    /*void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos, 0.5f);
    }*/

    // Update is called once per frame
    void Update()
    {
        switch (condition)
        {
            case "OnFire":
                if (burnt < 5 && damaged_state_persec <= 0)
                {
                    damaged_state_persec = 1;
                    hp -= 10;
                    burnt++;

                }
                if (burnt == 5)
                {
                    condition = "normal";
                    burnt = 0;
                }
                break;

            case "poisoned":
                if (poisoned < 5 && damaged_state_persec <= 0)
                {
                    damaged_state_persec = 1;
                    hp -= 5;
                    poisoned++;
                    if (poisoned == 5)
                    {
                        condition = "normal";
                        poisoned = 0;
                    }
                }
                break;
            case "spiked":
                if(spikecd<=0)
                {
                    hp -= 30;
                    condition = "normal";
                    spikecd = 3f;
                }
                break;
            case "haunted":
                if (haunted<3&& damaged_state_persec <= 0)
                {
                    damaged_state_persec = 1;
                    hp -= 10;
                    haunted++;
                    if (haunted == 3)
                    {
                        condition = "normal";
                        haunted = 0;
                    }
                }
                break;
                //default:
        }
        if (condition != "normal")
        {
            damaged_state_persec -= Time.deltaTime;
        }
        if (spikecd > 0)
        {
            spikecd -= Time.deltaTime;
        }
        Debug.Log(hp);
        Vector3 charpos = transform.position;
        Vector3Int cellcenterpos = FindObjectOfType<wave_class>().get_cent(charpos);
        Vector2 movement_vector = new Vector2(0, 0);

        if (stop == false)
        {
            //Debug.Log(" dest " + wp[wp_in_progress]);

            //Debug.Log(" adjx,adjy " + adjustx + " " + adjusty);

            //Vector3 charpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);


            //Debug.Log(" mypos " + cellcenterpos);


            if (cellcenterpos.x == wp[wp_in_progress].x && cellcenterpos.y == wp[wp_in_progress].y)
            {
                keydown = 'i';
                if (wp_in_progress < 2)
                { wp_in_progress += 1; }

            }


            if (cellcenterpos.x != wp[wp_in_progress].x)
            {
                if (cellcenterpos.x < wp[wp_in_progress].x)
                {
                    keydown = 'd';
                }
                else if (cellcenterpos.x > wp[wp_in_progress].x)
                {
                    keydown = 'a';
                }

            }


            if (cellcenterpos.y != wp[wp_in_progress].y)
            {
                if (cellcenterpos.y < wp[wp_in_progress].y)
                {
                    keydown = 'w';
                }
                else if (cellcenterpos.y > wp[wp_in_progress].y)
                {
                    keydown = 's';
                }

            }


            if (keydown == 'w')
            {
                // anim.SetBool("iswalking", true);
                isidle = false;
                charpos.y += panSpeed * Time.deltaTime;
                movement_vector.y = panSpeed * Time.deltaTime;
                // anim.SetFloat("input_y", 1);
                //anim.SetFloat("input_x", 0);
                //lastpressed = 0;
            }
            else if (keydown == 's')
            {
                //anim.SetBool("iswalking", true);
                isidle = false;
                charpos.y -= panSpeed * Time.deltaTime;
                movement_vector.y = panSpeed * Time.deltaTime;
                //anim.SetFloat("input_y", -1);
                //anim.SetFloat("input_x", 0);
                //lastpressed = 1;
            }
            else if (keydown == 'd')
            {
                //anim.SetBool("iswalking", true);
                isidle = false;
                charpos.x += panSpeed * Time.deltaTime;
                movement_vector.x = panSpeed * Time.deltaTime;
                //anim.SetFloat("input_x", 1);
                // anim.SetFloat("input_y", 0);
                //lastpressed = 2;
            }
            else if (keydown == 'a')
            {
                //anim.SetBool("iswalking", true);
                isidle = false;
                charpos.x -= panSpeed * Time.deltaTime;
                movement_vector.x = panSpeed * Time.deltaTime;
                //anim.SetFloat("input_x", -1);
                //anim.SetFloat("input_y", 0);
                //lastpressed = 3;
            }
            else
            {
                isidle = true;
                /*if (lastpressed == 0)
                {
                    anim.SetFloat("input_y", 1);
                    anim.SetFloat("input_x", 0);
                }
                else if (lastpressed == 1)
                {
                    anim.SetFloat("input_y", -1);
                    anim.SetFloat("input_x", 0);
                }
                else if (lastpressed == 2)
                {
                    anim.SetFloat("input_y", 0);
                    anim.SetFloat("input_x", 1);
                }
                else if (lastpressed == 3)
                {
                    anim.SetFloat("input_y", 0);
                    anim.SetFloat("input_x", -1);
                }
                anim.SetBool("iswalking", false);*/
            }

            transform.position = charpos;

        }
        if (Attack == true)
        {
            attack_cast_time -= Time.deltaTime;
            attack_cd_time -= Time.deltaTime;

            //trigger atk anim
            if (attack_cast_time < 0)
            {
                attack_cast_time = 1f;

            }
            if (attack_cd_time < 0)
            {

                attackpos = new Vector3(charpos.x + 0.5f, charpos.y + 0.5f, charpos.z);
                Collider2D[] enemytodmg = Physics2D.OverlapCircleAll(attackpos, attack_range, whatisenemy);

                if (enemytodmg != null)
                {
                    for (int i = 0; i < enemytodmg.Length; i++)
                    {
                        enemyname = enemytodmg[i].name;
                        switch (enemyname)
                        {
                            case "icewall":
                                enemytodmg[i].GetComponent<icewall>().hp -= dmg;
                                enemy_hp = enemytodmg[i].GetComponent<icewall>().hp;
                                FindObjectOfType<wave_class>().slash(attackpos);
                                enemyname = " ";
                                break;
                                //default:
                        }

                    }

                    // FindObjectOfType<wave_class>().slash(charpos);
                }
                else
                {
                    enemy_hp = 0;
                }

                attack_cd_time = 2f;
            }

        }
        if (enemy_hp <= 0)
        {
            Attack = false;
            movement_delay -= Time.deltaTime;
            if (movement_delay <= 0)
            {
                stop = false;
                movement_delay = 1f;
            }
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<GoldManager>().GetMoney(bounty);
        }

        Collider2D[] effect = Physics2D.OverlapCircleAll(charpos, 0.5f, whatisenemy);

        if (effect != null)
        {
            //Debug.Log("REREA");
            for (int i = 0; i < effect.Length; i++)
            {
                Debug.Log(effect[i].name);
                switch (effect[i].name)
                {
                    case "Frozen ground 1":
                        effectorname[effectorcounter] = "Frozen ground 1";
                        isthereEffect = true;
                        effectorcounter++;
                        break;
                    case "graveyard":
                        effectorname[effectorcounter] = "graveyard";
                        isthereEffect = true;
                        effectorcounter++;
                        break;
                    case "movement boost":
                        effectorname[effectorcounter] = "movement boost";
                        isthereEffect = true;
                        effectorcounter++;
                        break;

                }
            }

            effectorcounter = 0;
            if (isthereEffect == true)
            {
                for (int i = 0; i < effectorname.Length; i++)
                {
                    switch (effectorname[i])
                    {
                        case "Frozen ground 1":                           
                            if (panSpeed == 1f)
                            {
                                panSpeed = 2f;
                            }
                            else if (panSpeed == 1.25f)
                            {
                                panSpeed = 2.25f;
                            }

                            effectorname[i] =null;
                            break;
                        case "graveyard":
                            if (panSpeed == 1f)
                            {
                                panSpeed = 0.75f; 
                            }
                            else if (panSpeed == 1.25f)
                            {
                                panSpeed = 1f;
                            }
                            
                            effectorname[i] = null;
                            break;
                        case "movement boost":
                            if (panSpeed == 1f)
                            {
                                panSpeed = 1.25f;
                            }
                            else if (panSpeed == 2f)
                            {
                                panSpeed = 2.25f;
                            }

                            effectorname[i] = null;
                            break;

                    }
                }
                isthereEffect = false;
            }
            else
            {
                panSpeed = 1f;
            }


        }

    }

}
