using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static float deathX;
    public static float deathY;
    public static int startX;
    public static Vector3 startPosPlayer, startPosCam, startPosBrush;
    public static GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        player = gameObject;
        deathX = GameObject.Find("Main Camera").transform.position.x - 36f;
        if (transform.position.y < deathY || transform.position.x < deathX)
        {
            Die();
        }
    }
    public static void Set(){
        startX = 0;
        startPosPlayer.Set(startX, 0, 0);
        startPosCam.Set(startX, -5, -10);
        deathY = startPosCam.y - 21f;
        Reset();
    }
    public static void Reset(){
        Debug.Log(startPosCam);
        player.transform.position = startPosPlayer;
        GameObject.Find("Main Camera").transform.position = startPosCam;
        startPosBrush.Set(startPosCam.x - 30f, startPosCam.y, startPosCam.z);
        GameObject.Find("toothbrush").transform.position = startPosBrush;

    }
    public void Die()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        //transform.position = startPosPlayer;
        Reset();

        //unrot teeth
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Tooth");
        foreach (GameObject go in gos)
        {
            go.GetComponent<Rot>().UnrotTooth();
        }

        //unhide candy
        gos = GameObject.FindGameObjectsWithTag("Candy");
        foreach (GameObject go in gos)
        {
            //Debug.Log("unhide");
            go.SetActive(true);
            go.GetComponent<Candy>().UnhideCandy();
        }
    }
}
