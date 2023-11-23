using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public static int scoreValue;
    TMP_Text score;

    void Start()
    {
        scoreValue = 0;
        score = GetComponent<TMP_Text>();
    }


    void Update()
    {
        score.text = "Score: " + Rot.rotCount;
    }
}
