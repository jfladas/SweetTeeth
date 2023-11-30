using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Candy : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool hidden;
    public static int candyCount;
    public float superTime;
    public static bool super;

    void Start()
    {
        super = false;
        superTime = 2f;
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = true;

        candyCount = 0;
        hidden = false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !hidden)
        {
            gameObject.GetComponent<AudioSource>().Play();
            HideCandy();
            if(candyCount > 4){
                Time.timeScale = 1.0f;
                StartCoroutine(SuperRot());
            }
        }
    }
    public void HideCandy()
    {
        sr.enabled = false;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        if (candyCount < 5){
            candyCount++;
        }
        hidden = true;
    }
    public void UnhideCandy()
    {
        sr.enabled = true;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        candyCount = 0;
        hidden = false;
    }
    IEnumerator SuperRot(){
        super = true;
        yield return new WaitForSeconds(superTime);
        while (candyCount>0){
            if(Rot.rotCount > 0)
            {
                candyCount--;
            }else{
                candyCount = 0;
            }
            yield return new WaitForSeconds(superTime);
        }
        super = false;
    }
}
