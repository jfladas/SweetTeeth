using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float deathX;
    public float deathY;
    public int startX;
    public static Vector3 startPosPlayer, startPosCam;

    void Start()
    {
        startX = 0;
        startPosPlayer.Set(startX, 0, 0);
        startPosCam.Set(startX, -5, -10);
        deathY = startPosCam.y - 21f;
    }

    void Update()
    {
        deathX = GameObject.Find("Main Camera").transform.position.x - 36f;
        if (transform.position.y < deathY || transform.position.x < deathX)
        {
            Die();
        }
    }

    public void Die()
    {
        transform.position = startPosPlayer;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        GameObject.Find("Main Camera").transform.position = startPosCam;

        Play.Init();
    }
}
