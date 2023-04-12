using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class wave_class : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] spawnpoint = new GameObject[3];
    Vector3[] pos = new Vector3[3];
    Vector3Int[] centerpos = new Vector3Int[3];
    public GameObject knightprefab;
    public GameObject wizardprefab;
    public GameObject bardprefab;
    public GameObject slashprefab;
    public GameObject fireprefab;
    public GameObject wizfireballprefab;
    public GameObject thunderboltprefab;
    public GameObject icewallprefab;
    public GameObject Musicprefab;
    int nxtnamenum=0;
    int assignnum = 0;
    int assignnumk = 1;
    string[] formation=new string [12];
    int randomline=0;
    public Vector3Int wp1;

    // Use this for initialization


    
    public static void main(string[] args)
    {
        

    }
    void Start ()
    {
        // Vector3 pos = new Vector3(spawnpoint[0].transform.position.x, spawnpoint[0].transform.position.y+1, spawnpoint[0].transform.position.z);
        pos[0] = new Vector3(spawnpoint[0].transform.position.x, spawnpoint[0].transform.position.y, spawnpoint[0].transform.position.z);
        centerpos[0] = FindObjectOfType<wave_class>().get_cent(pos[0]);

        pos[1] = new Vector3(spawnpoint[1].transform.position.x, spawnpoint[1].transform.position.y, spawnpoint[1].transform.position.z);
        centerpos[1] = FindObjectOfType<wave_class>().get_cent(pos[1]);

        pos[2] = new Vector3(spawnpoint[2].transform.position.x, spawnpoint[2].transform.position.y, spawnpoint[2].transform.position.z);
        centerpos[2] = FindObjectOfType<wave_class>().get_cent(pos[2]);
        createknight();
        createknight();
        createknight();
        createknight();
        createknight();
        Instantiate(wizardprefab, centerpos[0], Quaternion.identity);
        Instantiate(bardprefab, centerpos[0], Quaternion.identity);
    }

    void createknight()
    {
        // Instantiate game object here

        randomline = Random.Range(0, 10);
        if (randomline == 1 || randomline == 2)
        {
            Instantiate(knightprefab, centerpos[0], Quaternion.identity);
            
        }
        else if(randomline == 3 || randomline == 4)
        {
            Instantiate(knightprefab, centerpos[1], Quaternion.identity);
            
        }
        else if (randomline == 5 || randomline == 6)
        {
            Instantiate(knightprefab, centerpos[2], Quaternion.identity);
            
        }

        formation[assignnum] = "knight";
        assignnum++;
    }

    public int assign_knight()
    {
        return assignnumk;
    }

    public int assign_tower()
    {
        return nxtnamenum;
    }
    public void slash(Vector3 cell)
    {
        Instantiate(slashprefab, cell, Quaternion.identity);
    }
    public void thunder(Vector3 cell)
    {
        Instantiate(thunderboltprefab, cell, Quaternion.identity);
    }
    public void fire(Vector3 cell)
    {
        Instantiate(fireprefab, cell, Quaternion.identity);
    }
    public void fireball(Vector3 cell)
    {
        Instantiate(wizfireballprefab, cell, Quaternion.identity);
    }
    public void Music(Vector3 cell)
    {
        Instantiate(Musicprefab, cell, Quaternion.identity);
    }

    public Vector3Int get_cent(Vector3 cell)
    {
        //Vector3Int tempcell = tilemap.WorldToCell(cell);
        return tilemap.WorldToCell(cell);
    }
    
    // Update is called once per frame
    void Update ()
    {
		
	}
}
