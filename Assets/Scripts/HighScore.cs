using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    TMP_Text highscoreText;
    public static int highscore;

    void Start()
    {
        highscore = 0;
        highscoreText = GetComponent<TMP_Text>();
        highscoreText.text = "";
    }


    void Update()
    {
        
        if (Rot.rotCount > highscore)
        {
            highscore = Rot.rotCount;
        }

        highscoreText.text = "" + highscore;
    }
}
