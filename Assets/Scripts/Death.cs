using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Death : MonoBehaviour
{
    public float deathX;
    public float deathY;
    public int startX;
    public static Vector3 startPosPlayer, startPosCam;
    public static bool dead;
    public AudioSource audio;

    void Start()
    {
        dead = false;
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
        if (dead)
        {
            GameObject.Find("FScore_f").GetComponent<TMP_Text>().enabled = true;
            GameObject.Find("FHighscore_f").GetComponent<TMP_Text>().enabled = true;
            GameObject.Find("Fail").GetComponent<Image>().enabled = true;
            GameObject.Find("FOverlay").GetComponent<Image>().enabled = true;
            GameObject.Find("FReplay").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.Find("FScore_f").GetComponent<TMP_Text>().enabled = false;
            GameObject.Find("FHighscore_f").GetComponent<TMP_Text>().enabled = false;
            GameObject.Find("Fail").GetComponent<Image>().enabled = false;
            GameObject.Find("FOverlay").GetComponent<Image>().enabled = false;
            GameObject.Find("FReplay").GetComponent<Image>().enabled = false;
        }
    }

    public void Die()
    {
        transform.position = startPosPlayer;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        GameObject.Find("Main Camera").transform.position = startPosCam;
        dead = true;
        Play.started = false;
        Play.Init();
        audio.Play();
    }
}
