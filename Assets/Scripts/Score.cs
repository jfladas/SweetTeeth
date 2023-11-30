using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;

    void Start()
    {
        score = GetComponent<TMP_Text>();
    }


    void Update()
    {
        score.text = "" + Rot.rotCount;
    }
}
