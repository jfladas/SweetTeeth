using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Win : MonoBehaviour
{
    public static bool win;
    void Start()
    {
        win = false;
    }
    private void Update() {
        if(win){
            GameObject.Find("Score_f").GetComponent<TMP_Text>().enabled = true;
            GameObject.Find("Highscore_f").GetComponent<TMP_Text>().enabled = true;
            GameObject.Find("Win").GetComponent<Image>().enabled = true;
            GameObject.Find("Overlay").GetComponent<Image>().enabled = true;
            GameObject.Find("Replay").GetComponent<Image>().enabled = true;
        }else{
            GameObject.Find("Score_f").GetComponent<TMP_Text>().enabled = false;
            GameObject.Find("Highscore_f").GetComponent<TMP_Text>().enabled = false;
            GameObject.Find("Win").GetComponent<Image>().enabled = false;
            GameObject.Find("Overlay").GetComponent<Image>().enabled = false;
            GameObject.Find("Replay").GetComponent<Image>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            WinGame();
        }
    }

    void WinGame(){
        Play.started = false;
        win = true;
        Play.Init();
    }
}
