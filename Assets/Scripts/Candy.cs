using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Candy : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool hidden;
    public static int candyCount;
    TMP_Text candyText;
    public float superTimer;

    void Start()
    {
        superTimer = 5f;
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = true;

        candyCount = 0;
        hidden = false;
        candyText = GameObject.Find("CandyCount").GetComponent<TMP_Text>();
        candyText.text = "Candy: " + candyCount + "/4";
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !hidden)
        {
            HideCandy();
            if(candyCount > 4){
                SuperRot();
            }
        }
    }
    public void HideCandy()
    {
        sr.enabled = false;
        candyCount++;
        candyText.text = "Candy: " + candyCount + "/4";
        hidden = true;
    }
    public void UnhideCandy()
    {
        sr.enabled = true;
        candyCount = 0;
        candyText.text = "Candy: " + candyCount + "/4";
        hidden = false;
    }
    public void SuperRot(){
        //...
    }
}
