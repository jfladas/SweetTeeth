using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    bool isHovering = false;
    public float timeToWait = 2.3f;
    float timeLeft;
    public static bool started = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cursor") && !isHovering && !started)
        {
            gameObject.GetComponent<AudioSource>().Play();
            timeLeft = timeToWait;
            isHovering = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Cursor") && !started)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            isHovering = false;
        }
    }

    void Update()
    {
        if (isHovering)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isHovering = false;
                LoadGame();
            }
        }else{
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }

    public static void LoadGame()
    {
        started = true;
        Win.win = false;
        Rot.rotCount = 0;
    }

    public static void Init()
    {
        started = false;
        PlayerMovement.init = false;
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
            go.SetActive(true);
            go.GetComponent<Candy>().UnhideCandy();
        }
    }
}
