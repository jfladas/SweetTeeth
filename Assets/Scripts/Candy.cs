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
    TMP_Text candyText;
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
        candyText = GameObject.Find("CandyCount").GetComponent<TMP_Text>();
    }
    private void Update() {

        candyText.text = "Candy: " + candyCount + "/5";
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !hidden)
        {
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
        if(candyCount < 5){
            candyCount++;
        }
        hidden = true;
    }
    public void UnhideCandy()
    {
        sr.enabled = true;
        candyCount = 0;
        hidden = false;
    }
    IEnumerator SuperRot(){
        super = true;
        //Wait for seconds
        yield return new WaitForSeconds(superTime);
        candyCount--;
        yield return new WaitForSeconds(superTime);
        candyCount--;
        yield return new WaitForSeconds(superTime);
        candyCount--;
        yield return new WaitForSeconds(superTime);
        candyCount--;
        yield return new WaitForSeconds(superTime);
        candyCount--;
        super = false;
    }
}
