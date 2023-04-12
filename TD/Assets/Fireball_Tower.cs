using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Tower : Tower {

    // Use this for initialization
    Vector3 towerpos;
    Vector3 enemypos;
    string enemyname;
    public LayerMask whatisenemy;

    // Use this for initialization
    void Start()
    {
        towerpos = transform.position;
        attack_radius = 3f;
        dmg = 60;
        cost = 80;
        cd = 0f;

        FindObjectOfType<GoldManager>().UseMoney(cost);
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attack_radius);
    }
    // Update is called once per frame
    void Update()
    {

        Collider2D[] enemytodmg = Physics2D.OverlapCircleAll(towerpos, attack_radius, whatisenemy);
        Debug.Log(enemytodmg != null);
        if (enemytodmg != null)
        {
            if (cd > 0)
            {
                cd -= Time.deltaTime;
            }
            Debug.Log("re");
            if (cd <= 0)
            {
                for (int i = 0; i < enemytodmg.Length; i++)
                {
                    enemyname = enemytodmg[i].name;
                    Debug.Log("RERERER");
                    switch (enemyname)
                    {
                        case "knight(Clone)":
                            if (cd <= 0)
                            {

                                enemypos = enemytodmg[i].transform.position;
                                enemytodmg[i].GetComponent<kknight>().hp -= dmg;
                                FindObjectOfType<wave_class>().fire(enemypos);
                                enemyname = " ";
                                cd = 5f;
                            }
                            break;
                        case "wizard(Clone)":
                            if (cd <= 0)
                            {

                                enemypos = enemytodmg[i].transform.position;
                                enemytodmg[i].GetComponent<wizard>().hp -= dmg;
                                FindObjectOfType<wave_class>().fire(enemypos);
                                enemyname = " ";
                                cd = 5f;
                            }
                            break;
                        case "Bard(Clone)":
                            if (cd <= 0)
                            {

                                enemypos = enemytodmg[i].transform.position;
                                enemytodmg[i].GetComponent<wizard>().hp -= dmg;
                                FindObjectOfType<wave_class>().thunder(enemypos);
                                enemyname = " ";
                                cd = 5f;
                            }
                            break;
                            //default:

                    }



                }
            }
        }
    }
}
