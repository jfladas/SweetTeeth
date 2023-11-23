using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float deathX;
    public float deathY;
    public Vector3 startPosPlayer, startPosCam;

    void Start()
    {
        deathX = GameObject.Find("Main Camera").transform.position.x - 18f;
        deathY = -10f;
        startPosPlayer.Set(0, 0, 0);
        startPosCam.Set(0, 0, -10);
    }

    void Update()
    {
        if (transform.position.y < deathY)
        {
            Die();
        }
    }

    void Die()
    {
        transform.position = startPosPlayer;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        GameObject.Find("Main Camera").transform.position = startPosCam;

        //unrot
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Tooth");
        foreach (GameObject go in gos)
        {
            go.GetComponent<Rot>().Unrot();
        }
    }
}
